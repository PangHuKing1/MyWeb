﻿using Microsoft.AspNetCore.Mvc;
using BackGroundManagement.BLL;
using BackGroundManagement.Models;
using Newtonsoft.Json;

namespace BackGroundManagement.Controllers
{
    
    public class BGMController : Controller
    {
        private ComputerBLL computerBLL = new ComputerBLL();
        public IActionResult BGMMessage()
        {
            return View();
        }

        public IActionResult EditComputer()
        {
            return View();
        }

        [HttpPost]
        public JsonResult ComputerMessage(string key)
        {
            List<Computers> computers = computerBLL.GetAll(key);
            int Count = computers.Count();
            return Json(new {code = 0, data= computers, mag = "",count=Count});
        }

        public JsonResult Add(string param)
        {
            int Hcode;
            string Hmsg;
            Computers computers = JsonConvert.DeserializeObject<Computers>(param);

            

            bool IsEdit = computerBLL.AddComputer(computers);
            if (!IsEdit)
            {
                Hcode = 1;
                Hmsg = "添加失败";
            }
            else
            {
                Hcode = 0;
                Hmsg = "添加成功";
            }

            return Json(new { code = Hcode, msg = Hmsg });
        }

        public JsonResult Edit(string param)
        {
            int Hcode;
            string Hmsg;
            Computers computers = JsonConvert.DeserializeObject<Computers>(param);

            bool IsEdit = computerBLL.EditComputer(computers);
            if (!IsEdit)
            {
                Hcode = 1;
                Hmsg = "修改失败";
            }
            else
            {
                Hcode = 0;
                Hmsg = "修改成功";
            }

            return Json(new { code = Hcode, msg = Hmsg });
        }

       public JsonResult Delete(Guid guid)
        {
            int Hcode;
            string Hmsg;
            bool IsDel = computerBLL.DelComputer(guid);
            if (!IsDel)
            {
                Hcode = 1;
                Hmsg = "删除失败";
            }
            else
            {
                Hcode = 0;
                Hmsg = "删除成功";
            }
            return Json(new {code = Hcode,msg=Hmsg});
        }
        

    }
}
