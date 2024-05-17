﻿using BackGroundManagement.DAL;
using BackGroundManagement.Models;
namespace BackGroundManagement.BLL
{
    public class ComputerBLL
    {
        private ComputerDAL computerDAL = new ComputerDAL();
        public List<Computers> GetAll(string key)
        {
            return computerDAL.GetAll(key);
        }
        public bool AddComputer(Computers computer)
        {
            return computerDAL.AddComputer(computer);
        }
        public bool EditComputer(Computers computer)
        {
            return computerDAL.EditComputer(computer);
        }
        public bool DelComputer(Guid guid)
        {
            return computerDAL.DelComputer(guid);
        }
    }
}
