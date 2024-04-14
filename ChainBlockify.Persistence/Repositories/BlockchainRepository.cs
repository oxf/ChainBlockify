using ChainBlockify.Application.Interfaces;
using ChainBlockify.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainBlockify.Persistence.Repositories
{
    internal class BlockchainRepository(AppDbContext _dbContext) : IRepository<Blockchain>
    {
        public async Task<IEnumerable<Blockchain>> GetAllAsync(CancellationToken cancellationToken)
        {
            try
            {
                return await _dbContext.BlockchainDbSet.ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred while retrieving all blockchains.", ex);
            }
        }

        public async Task<Blockchain> GetByIdAsync(int Id, CancellationToken cancellationToken)
        {
            try
            {
                return await _dbContext.BlockchainDbSet.Include(x => x.Sources).FirstOrDefaultAsync(x => x.Id == Id, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error occurred while retrieving blockchain by ID {Id}.", ex);
            }
        }
        public async Task<Blockchain> CreateAsync(Blockchain entity, CancellationToken cancellationToken)
        {
            try
            {
                _dbContext.BlockchainDbSet.Add(entity);
                await _dbContext.SaveChangesAsync(cancellationToken);
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred while creating the blockchain.", ex);
            }
        }

        public async Task<Blockchain> UpdateAsync(Blockchain entity, CancellationToken cancellationToken)
        {
            try
            {
                var entityToUpdate = await _dbContext.BlockchainDbSet.FindAsync(entity.Id, cancellationToken);
                entityToUpdate.Name = entity.Name;
                await _dbContext.SaveChangesAsync(cancellationToken);
                return entityToUpdate;
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred while updating blockchain.", ex);
            }
        }
        public async Task DeleteAsync(int Id, CancellationToken cancellationToken)
        {
            try
            {
                var entityToDelete = _dbContext.BlockchainDbSet.FindAsync(Id, cancellationToken);
                _dbContext.BlockchainDbSet.Remove(await entityToDelete);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error occurred while deleting blockchains by Id {Id}.", ex);
            }
        }

    }
}
