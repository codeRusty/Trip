﻿using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Trip.Application.Common.FileManager;
using Trip.Application.Common.Helpers;
using Trip.Creator.Application.Contracts.Persistance;
using Trip.Creator.Domain.Entities;
using Trip.Domain.Common.Messaging;

namespace Trip.Creator.Application.Feature.Content.Command.CreateContent
{
    public class CreateContentCommandHandler : IRequestHandler<CreateContentCommandRequest, CreateContentCommandResponse>
    {
        private readonly IFileService _fileService;
        private readonly ICreationWriterRepository _creationWriterRepository;
        private readonly ICreationResourceWriterRepository _creationResourceWriterRepository;
        private readonly IMapper _mapper;
        private readonly IBusPublisher _busPublisher;

        public CreateContentCommandHandler(IFileService fileService, ICreationWriterRepository creationWriterRepository, IMapper mapper, IBusPublisher busPublisher, ICreationResourceWriterRepository creationResourceWriterRepository)
        {
            _creationWriterRepository = creationWriterRepository;
            _mapper = mapper;
            _busPublisher = busPublisher;
            _fileService = fileService;
            _creationResourceWriterRepository = creationResourceWriterRepository;
        }

        public async Task<CreateContentCommandResponse> Handle(CreateContentCommandRequest request, CancellationToken cancellationToken)
        {
            var creationResource = new List<CreationResource>();
            foreach (var formFile in request.files)
            {
                if (formFile.Length > 0)
                {
                    var content = formFile.ReadAsBytes();
                    var path = await _fileService.SaveFileAsync(@"D:\Work\Trip\Trip\vCloud", formFile.FileName, content);

                    var resource = new CreationResource();
                    resource.Path = path;
                    resource.MimeType = Path.GetExtension(path);
                    creationResource.Add(resource);
                }
            }

            var creation = _mapper.Map<Creation>(request);
            await _creationWriterRepository.SaveAsync(creation);

            foreach (var item in creationResource)
            {
                item.Creation = creation;
                await _creationResourceWriterRepository.SaveAsync(item);
            }

            // Upload the files are create a path and save to db.
            // then add a queue to process this post. ProcessMemories Thumbnail Generation for three resolutions

            // Return
            return new CreateContentCommandResponse();
        }
    }
}
