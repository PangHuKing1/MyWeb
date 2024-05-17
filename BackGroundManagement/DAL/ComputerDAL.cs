﻿using System.Data.SqlClient;
using BackGroundManagement.Commons;
using BackGroundManagement.Models;
namespace BackGroundManagement.DAL
{
    public class ComputerDAL
    {
        ///<summary>
        ///根据搜索的参数查询所有数据
        /// </summary>
        /// <returns></returns>
        public List<Computers> GetAll(string key)
        {
            List<Computers> computerList = new List<Computers>();
            JdbcUtil jdbcUtil = new JdbcUtil();

            string query = "select * from Computers where 1=1 ";
            //根据搜索参数搜索数据
            if (!string.IsNullOrEmpty(key))
            {
                query += string.Format("and ( Name like '%{0}%' or Department like '%{0}%' )", key);
            }
            SqlDataReader data = jdbcUtil.select(query);
            while (data.Read())
            {
                Computers computer = new Computers();
                computer.GUID = (Guid)data["guid"];
                computer.Department = (string)data["department"];
                computer.SecDepartment = (string)data["secDepartment"];
                computer.Name = (string)data["name"];
                computer.Level = (string)data["level"];
                computer.Status = (string)data["status"];
                computer.Config = (string)data["config"];
                computer.Memo = (string)data["Memo"];
                computerList.Add(computer);
            }
            JdbcUtil.conn.Close();
            return computerList;
        }

        ///<summary>
        ///新增数据
        ///</summary>
        ///<param name="computer"></param>
        public bool AddComputer(Computers computer)
        {
            Guid guid = Guid.NewGuid();
            computer.GUID = guid;
            string insertSql = string.Format("insert into Computers values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')",
                                               computer.Department, computer.SecDepartment, computer.Name, computer.Level,
                                               computer.Status, computer.Config, computer.Memo,computer.GUID);
            int res = JdbcUtil.ExecuteUpdate(insertSql);
            if(res == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 编辑数据
        /// </summary>
        /// <param name="computer"></param>
        /// <returns></returns>
        public bool EditComputer (Computers computer)
        {
            string updSql = string.Format("update Computers set Department='{0}',SecDepartment='{1}',Name='{2}',Level='{3}',Status='{4}',Config='{5}',Memo='{6}' where GUID = '{7}'",
                                           computer.Department, computer.SecDepartment, computer.Name, computer.Level,
                                           computer.Status, computer.Config, computer.Memo, computer.GUID);
            int res = JdbcUtil.ExecuteUpdate(updSql);
            if (res == 1)
            {
                return true;
            }
            else { return false; }
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="computer"></param>
        /// <returns></returns>
        public bool DelComputer (Guid guid)
        {
            string delSql = string.Format("delete from Computers where GUID='{0}'", guid);
            int res = JdbcUtil.ExecuteUpdate(delSql);
            if (res == 1)
            {
                return true;
            }
            else { return false ; }
        }
    }
}
