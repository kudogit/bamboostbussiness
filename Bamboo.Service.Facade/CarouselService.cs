using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bamboo.Core.Constants;
using Bamboo.Core.Entities;
using Bamboo.Core.Models.Carousel;
using Bamboo.Data.File;
using Bamboo.Data.IRepositories;
using Bamboo.DependencyInjection.Attributes;
using Bamboo.Util;
using Bamboo.Util.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Bamboo.Service.Facade
{
    [ScopeDependency(ServiceType = typeof(ICarouselService))]
    public class CarouselService : ICarouselService
    {
        private readonly ICarouselRepository _carouselRepository;
        private readonly IFileRepository _fileRepository;
        private readonly ConfigSettings _configSettings;

        public CarouselService(ICarouselRepository carouselRepository, IFileRepository fileRepository,
            ConfigSettings configSettings)
        {
            _carouselRepository = carouselRepository;
            _fileRepository = fileRepository;
            _configSettings = configSettings;
        }

        public Task<int> AddAsync(AddCarouselModel model)
        {
            //  Add file

            var modelFileName = model.FileName;
            FileHelper.SaveFile(model.ContentBase64, ref modelFileName, _configSettings.UploadFileUrl);

            var fileRes = _fileRepository.Add(new Core.Entities.FileEntity
            {
                FileName = model.FileName,
                FileExtension = model.FileExtension,
                ContentBase64 = model.ContentBase64,
                EncodeFileName = modelFileName
            });

            _fileRepository.SaveChanges();

            var carouselRes = _carouselRepository.Add(new CarouselEntity
            {
                FileId = fileRes.Id,
                IsSelected = model.IsSelected
            });
            _carouselRepository.SaveChanges();

            return Task.FromResult(carouselRes.Id);
        }

        public Task EditAsync(EditCarouselModel model)
        {
            var entity = new CarouselEntity
            {
                Id = model.Id,
                IsSelected = model.IsSelected,
            };

            if (!string.IsNullOrEmpty(model.ContentBase64))
            {
                var modelFileName = model.FileName;
                FileHelper.SaveFile(model.ContentBase64, ref modelFileName, _configSettings.UploadFileUrl);

                var fileRes = _fileRepository.Add(new Core.Entities.FileEntity
                {
                    FileName = model.FileName,
                    FileExtension = model.FileExtension,
                    ContentBase64 = model.ContentBase64,
                    EncodeFileName = modelFileName
                });

                _fileRepository.SaveChanges();

                entity.FileId = fileRes.Id;

                _carouselRepository.Update(entity, x => x.IsSelected, x => x.FileId);
                _carouselRepository.SaveChanges();

                return Task.CompletedTask;
            }

            _carouselRepository.Update(entity, x => x.IsSelected);
            _carouselRepository.SaveChanges();
            return Task.CompletedTask;
        }

        public Task<EditCarouselModel> GetAsync(int id)
        {
            var carousel = _carouselRepository.GetSingle(x => x.Id == id);
            if (carousel == null)
                throw new BambooException(ErrorCode.ElementNotFound);

            var file = _fileRepository.GetSingle(x => x.Id == carousel.Id);

            return Task.FromResult(new EditCarouselModel
            {
                Id = carousel.Id,
                FileUrl = _configSettings.UploadFileUrl + file.EncodeFileName,
                IsSelected = carousel.IsSelected,
                FileName = file.FileName
            });
        }

        public Task<List<CarouselModel>> GetSelectedAsync()
        {
            var res = _carouselRepository.Get(x => x.IsSelected).Include(x => x.File).Select(x => new CarouselModel {
                Id = x.Id,
                IsSelected = x.IsSelected,
                FileId = x.File.Id,
                FileUrl = _configSettings.UploadFileUrl + x.File.EncodeFileName
            }).ToList();

            return Task.FromResult(res);
        }

        public Task<List<CarouselModel>> GetsAsync()
        {
            var res = _carouselRepository.Get().Include(x => x.File).Select(x => new CarouselModel
            {
                Id = x.Id,
                IsSelected = x.IsSelected,
                FileId = x.File.Id,
                FileUrl = _configSettings.UploadFileUrl + x.File.EncodeFileName
            }).ToList();

            return Task.FromResult(res);
        }
    }
}
