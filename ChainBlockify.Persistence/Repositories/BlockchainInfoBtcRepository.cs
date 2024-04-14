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
    internal class BlockchainInfoBtcRepository(AppDbContext _dbContext) : IRepository<BlockchainInfoBtc>
    {
        public async Task<IEnumerable<BlockchainInfoBtc>> GetAllAsync(CancellationToken cancellationToken)
        {
            try
            {
                return await _dbContext.BlockchainInfoBtcDbSet.ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred while retrieving all blockchains.", ex);
            }
        }

        public async Task<BlockchainInfoBtc> GetByIdAsync(int Id, CancellationToken cancellationToken)
        {
            try
            {
                return await _dbContext.BlockchainInfoBtcDbSet.FirstOrDefaultAsync(x => x.Id == Id, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error occurred while retrieving blockchain by ID {Id}.", ex);
            }
        }
        public async Task<BlockchainInfoBtc> CreateAsync(BlockchainInfoBtc entity, CancellationToken cancellationToken)
        {
            try
            {
                _dbContext.BlockchainInfoBtcDbSet.Add(entity);
                await _dbContext.SaveChangesAsync(cancellationToken);
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred while creating the blockchain.", ex);
            }
        }

        public async Task<BlockchainInfoBtc> UpdateAsync(BlockchainInfoBtc entity, CancellationToken cancellationToken)
        {
            try
            {
                var entityToUpdate = await _dbContext.BlockchainInfoBtcDbSet.FindAsync(entity.Id, cancellationToken);
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
                var entityToDelete = _dbContext.BlockchainInfoBtcDbSet.FindAsync(Id, cancellationToken);
                _dbContext.BlockchainInfoBtcDbSet.Remove(await entityToDelete);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error occurred while deleting blockchains by Id {Id}.", ex);
            }
        }

    }
}
