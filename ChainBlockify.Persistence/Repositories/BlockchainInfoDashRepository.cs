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
    internal class BlockchainInfoDashRepository(AppDbContext _dbContext) : IRepository<BlockchainInfoDash>
    {
        public async Task<IEnumerable<BlockchainInfoDash>> GetAllAsync(CancellationToken cancellationToken)
        {
            try
            {
                return await _dbContext.BlockchainInfoDashDbSet.ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred while retrieving all blockchains.", ex);
            }
        }

        public async Task<BlockchainInfoDash> GetByIdAsync(int Id, CancellationToken cancellationToken)
        {
            try
            {
                return await _dbContext.BlockchainInfoDashDbSet.FirstOrDefaultAsync(x => x.Id == Id, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error occurred while retrieving blockchain by ID {Id}.", ex);
            }
        }
        public async Task<BlockchainInfoDash> CreateAsync(BlockchainInfoDash entity, CancellationToken cancellationToken)
        {
            try
            {
                _dbContext.BlockchainInfoDashDbSet.Add(entity);
                await _dbContext.SaveChangesAsync(cancellationToken);
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred while creating the blockchain.", ex);
            }
        }

        public async Task<BlockchainInfoDash> UpdateAsync(BlockchainInfoDash entity, CancellationToken cancellationToken)
        {
            try
            {
                var entityToUpdate = await _dbContext.BlockchainInfoDashDbSet.FindAsync(entity.Id, cancellationToken);
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
                var entityToDelete = _dbContext.BlockchainInfoDashDbSet.FindAsync(Id, cancellationToken);
                _dbContext.BlockchainInfoDashDbSet.Remove(await entityToDelete);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error occurred while deleting blockchains by Id {Id}.", ex);
            }
        }

    }
}
