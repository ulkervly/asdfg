﻿using Microsoft.EntityFrameworkCore;
using PustokPractice.DAL;
using PustokPractice.Models;
using PustokPractice.Repositories.Interfaces;

namespace PustokPractice.Repositories.Implementations
{
    public class SliderRepository:ISliderRepository
    {
        private readonly AppDbContext _context;

        public SliderRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task CreateAsync(Slider slider)
        {
            await _context.Sliders.AddAsync(slider);
        }

        public void Delete(Slider slider)
        {
            _context.Sliders.Remove(slider);
        }

        public async Task<List<Slider>> GetAllAsync()
        {
            return await _context.Sliders.ToListAsync();
        }

        public async Task<Slider> GetByIdAsync(int id)
        {
            return await _context.Sliders.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}

