using capacitacion4b_api.DTOs.task;
using capacitacion4b_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capacitacion4b_api.Data.interfaces
{

    public interface iTaskService
    {

        /* crear tarea */
        public Task<taskModel?> Create(createTaskDto createTaskDto);
        /* */
        /*  */
        public Task<taskModel> Update(taskModel updateTaskDto);

    }

}
