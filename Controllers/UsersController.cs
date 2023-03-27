using AutoMapper;
using FoodsConnected.Contexts.UserInfo.Entities;
using FoodsConnected.Models;
using FoodsConnected.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FoodsConnected.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        public IUserInfoRepository _userInfoRepository { get; }
        public IMapper _mapper { get; }

        public UsersController(IUserInfoRepository userInfoRepository,
            IMapper mapper)
        {
            _userInfoRepository = userInfoRepository ??
                throw new ArgumentNullException(nameof(userInfoRepository));

            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        [HttpPost(Name = "AddUser")]
        public async Task<ActionResult<UserDTO>> AddUser([FromBody] UserForCreationDTO user)
        {
            if (await _userInfoRepository.UserNameExistsAsync(user.Name))
            {
                return Conflict("User name already exists");
            }

            var userEntity = _mapper.Map<UserEntity>(user);

            _userInfoRepository.AddUser(userEntity);

            await _userInfoRepository.SaveChangesAsync();

            var userToReturn = _mapper.Map<UserDTO>(userEntity);

            return CreatedAtRoute("GetUser",
                routeValues: new { userId = userToReturn.Id.ToString() },
                value: userToReturn);
        }

        [HttpGet(Name = "GetUsers")]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetUsers()
        {
            var userEntities = await _userInfoRepository.GetUsersAsync();

            return Ok(_mapper.Map<IEnumerable<UserDTO>>(userEntities));
        }

        [HttpGet("{userId}", Name = "GetUser")]
        public async Task<ActionResult<UserDTO>> GetUser(int userId)
        {
            var userEntity = await _userInfoRepository.GetUserAsync(userId);

            if (userEntity == null)
            {
                return userNotFoundReturn(userId);
            }

            return Ok(_mapper.Map<UserDTO>(userEntity));
        }

        [HttpPatch("{userId}", Name = "UpdateUser")]
        public async Task<ActionResult> UpdateUser(int userId, UserForUpdateDTO user)
        {
            var userEntity = await _userInfoRepository.GetUserAsync(userId);

            if (userEntity == null)
            {
                return userNotFoundReturn(userId);
            }

            if (await _userInfoRepository.UserNameExistsAsync(user.Name, userId))
            {
                return Conflict("User name already exists");
            }

            _mapper.Map(user, userEntity);

            await _userInfoRepository.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{userId}", Name = "DeleteUser")]
        public async Task<ActionResult> DeleteUser(int userId)
        {
            var userEntity = await _userInfoRepository.GetUserAsync(userId);

            if (userEntity == null)
            {
                return userNotFoundReturn(userId);
            }

            _userInfoRepository.DeleteUser(userEntity);

            await _userInfoRepository.SaveChangesAsync();

            return NoContent();
        }

        private ObjectResult userNotFoundReturn(int userId)
        {
            return NotFound($"No use with userId: {userId} exists");
        }
    }
}
