using System;
using System.Collections.Generic;
using System.Text;

namespace DEV.Domain.Rules
{
    public abstract class RuleHandler<TEntity>
    {
        protected RuleHandler<TEntity> _successor;

        public abstract void HandleRequest(List<TEntity> list);

        public void SetSuccessor(RuleHandler<TEntity> successor)
        {
            _successor = successor;
        }
    }
}
