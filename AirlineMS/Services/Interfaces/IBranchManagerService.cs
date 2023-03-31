using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AirlineMS.Models.Dtos;

namespace AirlineMS.Services.Interfaces
{
    public interface IBranchManagerService
    {
        BaseResponse<BranchManagerDto> Create(CreateBranchManagerRequestModel model);
        BaseResponse<BranchManagerDto> Get(string id);
        BaseResponse<BranchManagerDto> GetByEmail(string email);
    }
}