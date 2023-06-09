﻿using Microsoft.AspNetCore.Mvc;
using MyFinance.Webapi.Models;
using MyFinance.Webapi.Models.Converters;
using MyFinances.Core.Dtos;
using MyFinances.Core.Response;
using System;
using System.Collections.Generic;


namespace MyFinance.Webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationController : ControllerBase
    {
        private readonly UnitOfWork _unitOfWork;

        public OperationController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

      
        [HttpGet]
        public DataResponse<IEnumerable<OperationDto>> Get()
        {
            var response = new DataResponse<IEnumerable<OperationDto>>();

            try
            {
                response.Data = _unitOfWork.Operation.Get().ToDtos();
            }
            catch (Exception exception)
            {
                //logowanie do pliku...
                response.Errors.Add(new Error(exception.Source, exception.Message));
            }

            return response;
        }

        [HttpGet("{id}")]
        
        public DataResponse<OperationDto> Get(int id)
        {
            var response = new DataResponse<OperationDto>();

            try
            {
                response.Data = _unitOfWork.Operation.Get(id)?.ToDto();
            }
            catch (Exception exception)
            {
                //logowanie do pliku...
                response.Errors.Add(new Error(exception.Source, exception.Message));
            }

            return response;
        }

        [HttpPost]

        public DataResponse<int> Add(OperationDto operationDto)
        {
            var response = new DataResponse<int>();

            try
            {
                var operation = operationDto.ToDao();
                _unitOfWork.Operation.Add(operation);
                _unitOfWork.Complete();
                response.Data = operation.Id;
            }
            catch (Exception exception)
            {
                //logowanie do pliku...
                response.Errors.Add(new Error(exception.Source, exception.Message));
            }

            return response;
        }

        [HttpPut]

        public Response Update(OperationDto operation)
        {
            var response = new Response();

            try
            {
                _unitOfWork.Operation.Update(operation.ToDao());
                _unitOfWork.Complete();
               
            }
            catch (Exception exception)
            {
                //logowanie do pliku...
                response.Errors.Add(new Error(exception.Source, exception.Message));
            }

            return response;
        }
        [HttpDelete("{id}")]

        public Response Delete(int id)
        {
            var response = new Response();

            try
            {
                _unitOfWork.Operation.Delete(id);
                _unitOfWork.Complete();

            }
            catch (Exception exception)
            {
                //logowanie do pliku...
                response.Errors.Add(new Error(exception.Source, exception.Message));
            }

            return response;
        }

        [HttpGet("{recordsCount}/{page}")]

        public DataResponse<IEnumerable<OperationDto>> Get(int recordsCount, int page)
        {
            var response = new DataResponse<IEnumerable<OperationDto>>();

            try
            {
                if (recordsCount<=0)
                {
                    throw new ArgumentException(nameof(recordsCount));
                }
                if (page <= 0)
                {
                    throw new ArgumentException(nameof(page));
                }
                response.Data = _unitOfWork.Operation.Get(recordsCount,page).ToDtos();
            }
            catch (Exception exception)
            {
                //logowanie do pliku...
                response.Errors.Add(new Error(exception.Source, exception.Message));
            }

            return response;
        }
    }
}
