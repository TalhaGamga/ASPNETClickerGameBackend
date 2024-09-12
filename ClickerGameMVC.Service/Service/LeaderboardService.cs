using ClickerGameMVC.DataAccess.Repositories;
using ClickerGameMVC.Models;
using ClickerGameMVC.Service.Abstract;
using Microsoft.EntityFrameworkCore;

namespace ClickerGameMVC.Service.Service
{
    public class LeaderboardService : ILeaderboardService
    {
        private readonly IRepository<User> _repository;

        private readonly Dictionary<LeaderboardSortType, Func<IQueryable<User>, IOrderedQueryable<User>>> sortExpressions =
            new Dictionary<LeaderboardSortType, Func<IQueryable<User>, IOrderedQueryable<User>>>() {
                { LeaderboardSortType.GoldAmountAscending, q => q.OrderBy(u => u.UserStat.GoldAmount) },
                { LeaderboardSortType.GoldAmountDescending, q => q.OrderByDescending(u => u.UserStat.GoldAmount) },
                { LeaderboardSortType.ClickCountAscending, q => q.OrderBy(u => u.UserStat.ClickCount) },
                { LeaderboardSortType.ClickCountDescending, q => q.OrderByDescending(u => u.UserStat.ClickCount) }
            };

        public LeaderboardService(IRepository<User> repository)
        {
            _repository = repository;
        }

        public ICollection<User> GetAllInOrder(LeaderboardSortType sortType)
        {
            var queryable = _repository.GetQuareyble().Include("UserStat");

            if (sortExpressions.ContainsKey(sortType))
            {
                var orderedQueryable = sortExpressions[sortType](queryable);

                return orderedQueryable.ToList();
            }

            return queryable.ToList();
        }
    }
}
