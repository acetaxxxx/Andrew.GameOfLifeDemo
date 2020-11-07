﻿using System;

namespace GameHost1.Universes.Evance.Milestone3
{
    public class Life : ILife, IDisposable
    {
        private readonly ITimeReadOnly _time;
        private readonly IPlanetReadOnly _planet;
        private readonly LifeSettings _lifeSettings;

        /// <summary>
        /// 下一次有效進化時間 (在同一個時間區間內，進化一次跟進化多次的意義相同)
        /// </summary>
        private TimeSpan _leftTimeForEvolving;
        private readonly TimeSpan _intervalTimespan;
        private bool isDisposed;

        public bool IsAlive { get; private set; }

        public (int X, int Y) Coordinates { get; }

        public Life(LifeSettings lifeSettings)
        {
            #region 檢查傳入參數

            _time = lifeSettings?.Time ?? throw new ArgumentNullException(nameof(LifeSettings.Time));

            _planet = lifeSettings?.Planet ?? throw new ArgumentNullException(nameof(LifeSettings.Planet));

            _lifeSettings = lifeSettings ?? throw new ArgumentNullException(nameof(lifeSettings));

            CheckSettings();

            #endregion

            IsAlive = _lifeSettings.InitIsAlive;

            Coordinates = _lifeSettings.InitCoordinates;

            // 初始化下一次演化的時間，即為第一次演化的時間
            _leftTimeForEvolving = TimeSpan.FromMilliseconds(_lifeSettings.TimeSettings.StartDelay);

            _intervalTimespan = TimeSpan.FromMilliseconds(_lifeSettings.TimeSettings.Interval);

            _time.Elapsing += (sender, eventArgs) => this.TryEvolve(sender, eventArgs);
        }

        private void CheckSettings()
        {
            if (_lifeSettings.InitCoordinates.x < 0) throw new ArgumentOutOfRangeException(nameof(_lifeSettings.InitCoordinates.x));
            if (_lifeSettings.InitCoordinates.y < 0) throw new ArgumentOutOfRangeException(nameof(_lifeSettings.InitCoordinates.y));
        }

        protected virtual bool CanAdaptToEnvironment(int aroundAliveLivesCount)
        {
            if (this.IsAlive)
            {
                if (aroundAliveLivesCount < 2 || aroundAliveLivesCount > 3)
                {
                    return false;
                }
            }
            else
            {
                if (aroundAliveLivesCount == 3)
                {
                    return true;
                }
            }

            return this.IsAlive;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="timeEventArgs"></param>
        /// <returns>是否有演化</returns>
        protected virtual bool TryEvolve(object sender, TimeEventArgs timeEventArgs)
        {
            // 先看看演化時間到了沒
            if (timeEventArgs.CurrentTime >= this._leftTimeForEvolving)
            {
                // 演化
                var aroundAliveLivesCount = _planet.GetAroundAliveLivesCount(this.Coordinates);

                this.IsAlive = CanAdaptToEnvironment(aroundAliveLivesCount);

                // 計算下一次有效演化時間
                do
                {
                    this._leftTimeForEvolving = this._leftTimeForEvolving.Add(_intervalTimespan);
                } while (timeEventArgs.NextTime > this._leftTimeForEvolving);

                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 轉換為花瓶 Life 。
        /// </summary>
        /// <returns></returns>
        public LifeWithAppearanceOnly ConvertToAppearanceOnlyLife()
        {
            return new LifeWithAppearanceOnly(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!isDisposed)
            {
                if (disposing)
                {
                    // TODO: 處置受控狀態 (受控物件)
                    _time.Elapsing -= (sender, eventArgs) => this.TryEvolve(sender, eventArgs);
                }

                // TODO: 釋出非受控資源 (非受控物件) 並覆寫完成項
                // TODO: 將大型欄位設為 Null
                isDisposed = true;
            }
        }

        // // TODO: 僅有當 'Dispose(bool disposing)' 具有會釋出非受控資源的程式碼時，才覆寫完成項
        // ~Life()
        // {
        //     // 請勿變更此程式碼。請將清除程式碼放入 'Dispose(bool disposing)' 方法
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // 請勿變更此程式碼。請將清除程式碼放入 'Dispose(bool disposing)' 方法
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
