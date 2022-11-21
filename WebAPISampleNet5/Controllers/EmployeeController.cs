using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using AutoMapper;
using System.Text;
using Newtonsoft.Json;


namespace WebAPISampleNet5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        
        List<EmployeeModel> employees;

        public EmployeeController()
        {
            employees = new List<EmployeeModel>();

            employees.Add(new EmployeeModel { Name = "홍길동", Email = "honggin@naver.com" });
            employees.Add(new EmployeeModel { Name = "김영희", Email = "younghee@naver.com" });
            employees.Add(new EmployeeModel { Name = "유재석", Email = "youjaesuk@naver.com" });
        }


        // GET: api/<EmployeeController>
        /// <summary>
        /// GET :  직원 기본 연락 정보 전체 목록 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetList()
        {
            if (employees.Count() == 0)
            {
                return NoContent();
                
            }
            else
            {
                return Ok(employees);
            }
        }

        // GET api/<EmployeeController>/5
        /// <summary>
        /// GET :  개별 직원 기본 연락 정보
        /// </summary>
        /// <param name="name">이름</param>
        /// <returns></returns>
        [HttpGet("{name}")]
        public IActionResult Get(string name)
        {
            var employee = employees.Where(emp => emp.Name == System.Web.HttpUtility.HtmlDecode(name));

            if(employee.Count() == 0)
            {
                return NoContent();
            }
            else
            {
                return Ok(employee.First());
            }
        }


        /// <summary>
        /// cvs 형식으로  body 전달 
        /// </summary>
        /// <param name="emp">회원정보 cvs 형식</param>
        /// <returns></returns>
        [HttpPost]
        [Route("cvs")]
        [Consumes("text/plain")]
        public IActionResult Post([FromBody] string cvs)
        {
            var employee = new List<EmployeeModel>();
            foreach (string line in cvs.Split("\n"))
            {
                var emp = line.Split(",");
                employee.Add(new EmployeeModel { Name = emp[0], Email = emp[1] });
            }

            var config = new MapperConfiguration(cfg => cfg.CreateMap<EmployeeModel, EmployeeModelDTO>());
            var mapper = new Mapper(config);
            var empDTO = mapper.Map<List<EmployeeModelDTO>>(employee);

            var employeeAll = mapper.Map<List<EmployeeModelDTO>>(employees);
            employeeAll = employeeAll.Union(empDTO).ToList();

            return Ok(employeeAll);
        }


        /// <summary>
        /// json 형식으로 body 전달
        /// </summary>
        /// <param name="emp">회원정보 jons 형식</param>
        /// <returns></returns>
        [HttpPost]
        [Route("json")]
        [Consumes("application/json")]
        public IActionResult PostJson([FromBody] List<EmployeeModel> json)
        {
            //Initialize the mapper

            //todo service layer 작업
            var config = new MapperConfiguration(cfg =>cfg.CreateMap<EmployeeModel, EmployeeModelDTO>());
            var mapper = new Mapper(config);
            var empDTO = mapper.Map<List<EmployeeModelDTO>>(json);

            var employeeAll = mapper.Map<List<EmployeeModelDTO>>(employees);
            employeeAll = employeeAll.Union(empDTO).ToList();


            return Ok(employeeAll);
        }


        /// <summary>
        /// 파일을 이용하여 회원등록
        /// </summary>
        /// <param name="file">cvs, json 만 가능</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> PostAsync(IFormFile file)
        {
            var employee = await this.ReadFileAsync(file);


            //add  service 작업
            var config = new MapperConfiguration(cfg => cfg.CreateMap<EmployeeModel, EmployeeModelDTO>());
            var mapper = new Mapper(config);
            
            var empDTO = mapper.Map<List<EmployeeModelDTO>>(employee);
            var employeeAll = mapper.Map<List<EmployeeModelDTO>>(employees);
            employeeAll = employeeAll.Union(empDTO).ToList();


            return CreatedAtAction(nameof(GetList), employeeAll);
        }


        /// <summary>
        /// 파일을 읽어 처리한다.
        /// </summary>
        /// <param name="file">넘어온 파일 정보</param>
        /// <returns></returns>
        private async Task<List<EmployeeModel>> ReadFileAsync(IFormFile file)
        {
            var employee = new List<EmployeeModel>();

            if (file.FileName.Split(".").Last().ToLower() == "cvs")
            {
                using (var reader = new StreamReader(file.OpenReadStream()))
                {
                    while (reader.Peek() >= 0)
                    {
                        var line = await reader.ReadLineAsync();
                        var emp = line.Split(",");
                        employee.Add(new EmployeeModel { Name = emp[0], Email = emp[1] });
                    }
                }
            }
            else if (file.FileName.Split(".").Last().ToLower() == "json")
            {
                var result = new StringBuilder();
                using (var reader = new StreamReader(file.OpenReadStream()))
                {
                    while (reader.Peek() >= 0)
                    {
                        result.Append(await reader.ReadLineAsync());
                    }
                }

                //{[  { "name": "홍길동",		"email": "honggin@naver.com"    },	{ "name": "홍길동",		"email": "honggin@naver.com"    }]}
                employee = JsonConvert.DeserializeObject<List<EmployeeModel>>(result.ToString());
            }

            return employee;


        }

    }
}
