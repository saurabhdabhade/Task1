﻿using LibraryClass.Data;
using LibraryClass.Model;
using LibraryClass.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryClass.Repository
{
    public class RegisterRepository : IRegisterRepository
    {
        private readonly ApplicationDBContext _dbContext;
        public RegisterRepository(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Delete(int registerID)
        {
            var result = await _dbContext.registers.FirstOrDefaultAsync(u => u.RegisterID == registerID);
            if (result != null)
            {
                _dbContext.registers.Remove(result);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<Register> Get(int registerID)
        {
            return await _dbContext.registers.FirstOrDefaultAsync(u => u.RegisterID == registerID);
        }

        public async Task<IEnumerable<Register>> GetAll()   
        {
            return await _dbContext.registers.ToListAsync();
        }

        public async Task<Register> Register(Register register)
        {
            var result = await _dbContext.registers.AddAsync(register);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Register> Update(Register register)
        {
            var result = await _dbContext.registers.FirstOrDefaultAsync(u => u.RegisterID == register.RegisterID);
            if (result != null)
            {
                result.RegisterID = register.RegisterID;
                result.First_Name = register.First_Name;
                result.Last_Name = register.Last_Name;
                result.Password = register.Password;
                result.Email = register.Email;
                result.Confirm_Password = register.Confirm_Password;
                await _dbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}
