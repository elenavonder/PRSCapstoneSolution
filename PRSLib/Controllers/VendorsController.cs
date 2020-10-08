using Microsoft.Data.SqlClient;
using PRSLib.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PRSLib.Controllers
{
    public class VendorsController
    {
        public PrsConnection prsConnection { get; set; } = null;
        public VendorsController (PrsConnection prsConnection)
        {
            this.prsConnection = prsConnection;
        }

        public int Update(Vendor vendor)
        {
            var sql = "UPDATE Vendors SET" +
                " Code = @Code," +
                " Name = @Name," +
                " Address = @Address," +
                " City = @City," +
                " State = @State," + 
                " Zip = @Zip," +
                " PhoneNumber = @Phone," +
                " Email = @Email" +
                " WHERE Id = @Id;";
            var cmd = new SqlCommand(sql, prsConnection.sqlConnection);
            cmd.Parameters.AddWithValue("@Code", vendor.Code);
            cmd.Parameters.AddWithValue("@Name", vendor.Name);
            cmd.Parameters.AddWithValue("@Address", vendor.Address);
            cmd.Parameters.AddWithValue("@City", vendor.City);
            cmd.Parameters.AddWithValue("@State", vendor.State);
            cmd.Parameters.AddWithValue("@Zip", vendor.Zip);
            cmd.Parameters.AddWithValue("@Phone", vendor.Phone);
            cmd.Parameters.AddWithValue("@Email", vendor.Email);
            cmd.Parameters.AddWithValue("@Id", vendor.Id);

            return cmd.ExecuteNonQuery();
        }

        public int Vendor(Vendor vendor)
        {
            var sql = "INSERT Users (Code, Name, Address, City, State, Zip, PhoneNumber, Email)" +
                " VALUES (@Code, @Name, @Address, @City, @State, @Zip, @Phone, @Email);";
            var cmd = new SqlCommand(sql, prsConnection.sqlConnection);
            cmd.Parameters.AddWithValue("@Code", vendor.Code);
            cmd.Parameters.AddWithValue("@Name", vendor.Name);
            cmd.Parameters.AddWithValue("@Address", vendor.Address);
            cmd.Parameters.AddWithValue("@City", vendor.City);
            cmd.Parameters.AddWithValue("@State", vendor.State);
            cmd.Parameters.AddWithValue("@Zip", vendor.Zip);
            cmd.Parameters.AddWithValue("@Phone", vendor.Phone);
            cmd.Parameters.AddWithValue("@Email", vendor.Email);

            return cmd.ExecuteNonQuery();
        }

        public Vendor GetVendorPK(int Id)
        {
            var sql = "SELECT * From Vendors WHERE Id = @Id;";
            var cmd = new SqlCommand(sql, prsConnection.sqlConnection);
            cmd.Parameters.AddWithValue("@Id", Id);
            var sqlDataReader = cmd.ExecuteReader();
            if (!sqlDataReader.HasRows)
                return null;
            sqlDataReader.Read();
            var ven = new Vendor();
            ven.Code = Convert.ToString(sqlDataReader["Code"]);
            ven.Name = Convert.ToString(sqlDataReader["Name"]);
            ven.Address = Convert.ToString(sqlDataReader["Address"]);
            ven.City = Convert.ToString(sqlDataReader["City"]);
            ven.State = Convert.ToString(sqlDataReader["State"]);
            ven.Zip = Convert.ToString(sqlDataReader["Zip"]);
            ven.Phone = Convert.ToString(sqlDataReader["PhoneNumber"]);
            ven.Email = Convert.ToString(sqlDataReader["Email"]);

            sqlDataReader.Close();
            return ven;
        }

        public List<Vendor> GetVendors()
        {
            var sql = "SELECT * From Vendors;";
            var cmd = new SqlCommand(sql, prsConnection.sqlConnection);
            var vendors = new List<Vendor>();
            var sqlDataReader = cmd.ExecuteReader();
            while (sqlDataReader.Read())
            {
                var ven = new Vendor();
                ven.Code = Convert.ToString(sqlDataReader["Code"]);
                ven.Name = Convert.ToString(sqlDataReader["Name"]);
                ven.Address = Convert.ToString(sqlDataReader["Address"]);
                ven.City = Convert.ToString(sqlDataReader["City"]);
                ven.State = Convert.ToString(sqlDataReader["State"]);
                ven.Zip = Convert.ToString(sqlDataReader["Zip"]);
                ven.Phone = Convert.ToString(sqlDataReader["PhoneNumber"]);
                ven.Email = Convert.ToString(sqlDataReader["Email"]);
                
                vendors.Add(ven);
            }
            sqlDataReader.Close();
            return vendors;
        }

    }
}
