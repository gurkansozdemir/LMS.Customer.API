﻿using AutoMapper;
using EDU.Core.DTOs;
using EDU.Core.DTOs.UserDTOs;
using EDU.Core.Entities;
using EDU.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace EDU.API.Controllers
{
    public class UserController : CustomBaseController
    {
        private readonly IService<User> _service;
        private readonly IMapper _mapper;
        public UserController(IService<User> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var users = await _service.GetAllAsync();
            var userDtos = _mapper.Map<List<User>, List<GetUserDto>>(users.ToList());
            return Ok(CustomResponseDto<List<GetUserDto>>.Success(userDtos));
        }

        [HttpPost]
        public async Task<IActionResult> Add(SetUserDto userDto)
        {
            var user = _mapper.Map<SetUserDto, User>(userDto);
            await _service.AddAsync(user);
            return Ok(CustomResponseDto<NoContentDto>.Success());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _service.GetByIdAsync(id);
            var userDto = _mapper.Map<User, GetUserDto>(user);
            return Ok(CustomResponseDto<GetUserDto>.Success(userDto));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteById(int id)
        {
            var user = await _service.GetByIdAsync(id);
            await _service.RemoveAsync(user);
            return Ok(CustomResponseDto<NoContentDto>.Success());
        }

        [HttpPut]
        public async Task<IActionResult> Update(GetUserDto userDto)
        {
            var user = _mapper.Map<GetUserDto, User>(userDto);
            user.UpdatedOn = DateTime.Now;
            await _service.UpdateAsync(user);
            return Ok(CustomResponseDto<NoContentDto>.Success());
        }
    }
}