using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LigamaniaCoreApp.Data.DataModels.Base.Model
{
    // Implement this on your context
    public interface IContextDisposedState
    {
        bool IsDisposed { get; }
    }

    public class MyLazyLoader : ILazyLoader
    {
        private readonly ILazyLoader _efCoreLazyLoader;
        private readonly ICurrentDbContext _currentContext;

        public MyLazyLoader(ICurrentDbContext currentContext, IDiagnosticsLogger<DbLoggerCategory.Infrastructure> logger)
        {
            _currentContext = currentContext;
            _efCoreLazyLoader = new LazyLoader(currentContext, logger);
        }

        private bool ContextIsDisposed => ((IContextDisposedState)_currentContext.Context).IsDisposed;

        private bool AutoDetectChangesEnabled
        {
            get
            {
                return _currentContext.Context.ChangeTracker.AutoDetectChangesEnabled;
            }
            set
            {
                _currentContext.Context.ChangeTracker.AutoDetectChangesEnabled = value;
            }
        }

        public void Load(object entity, [CallerMemberName] string navigationName = null)
        {
            if (ContextIsDisposed)
                return;

            var originalChangeTrackingState = AutoDetectChangesEnabled;
            try
            {

                AutoDetectChangesEnabled = false;
                _efCoreLazyLoader.Load(entity, navigationName);
            }
            finally
            {
                if (originalChangeTrackingState)
                    AutoDetectChangesEnabled = true;
            }
        }

        public async Task LoadAsync(object entity, CancellationToken cancellationToken = default(CancellationToken), [CallerMemberName] string navigationName = null)
        {
            if (ContextIsDisposed)
                return;

            var originalChangeTrackingState = AutoDetectChangesEnabled;
            try
            {

                AutoDetectChangesEnabled = false;
                await _efCoreLazyLoader.LoadAsync(entity, cancellationToken, navigationName).ConfigureAwait(false);
            }
            finally
            {
                if (originalChangeTrackingState)
                    AutoDetectChangesEnabled = true;
            }
        }
    }

   // // Register the replacement service
   // new DbContextOptionsBuilder()
   //.ReplaceService<ILazyLoader, MyLazyLoader>();
}
