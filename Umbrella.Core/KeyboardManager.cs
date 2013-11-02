using System.Collections.Generic;
﻿using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace Umbrella.Core
{
    public delegate void UmbrellaKeyDown(object sender, KeyEventArgs args);
    public delegate void KeyDown(object sender, KeyEventArgs args);
    public delegate void UmbrellaKeyUp(object sender, KeyEventArgs args);

    public class KeyboardManager
    {
        private const Key UMBRELLA_01_KEY = Key.F2;
        private const Key UMBRELLA_02_KEY = Key.F3;
        private const Key UMBRELLA_03_KEY = Key.F4;
        private const Key UMBRELLA_04_KEY = Key.F5;
        private const Key UMBRELLA_05_KEY = Key.F6;
        private const Key UMBRELLA_06_KEY = Key.F7;

        public event UmbrellaKeyDown UmbrellaKeyDown;
        public event UmbrellaKeyUp UmbreallaKeyUp;

        public event KeyDown KeyDown;

        public KeyboardManager(DependencyObject dependencyObject)
        {
            Keyboard.AddKeyDownHandler(dependencyObject, KeyEventHandler);
            Keyboard.AddKeyUpHandler(dependencyObject, KeyUpHandler);
        }

        public IEnumerable<bool> UmbrellaStatuses
        {
            get
            {
                return new []
                {
                    Umbrella01, 
                    Umbrella02, 
                    Umbrella03, 
                    Umbrella04, 
                    Umbrella05, 
                    Umbrella06
                };
            }
        }

        public int ExistingCount()
        {
            return new[]
                {
                    Umbrella01, 
                    Umbrella02, 
                    Umbrella03, 
                    Umbrella04, 
                    Umbrella05, 
                    Umbrella06
                }.Count(u => u);
        }

        public bool Umbrella01
        {
            get
            {
                return CheckUmbrellaStatus(UMBRELLA_01_KEY);
            }
        }

        public bool Umbrella02
        {
            get
            {
                return CheckUmbrellaStatus(UMBRELLA_02_KEY);
            }
        }

        public bool Umbrella03
        {
            get
            {
                return CheckUmbrellaStatus(UMBRELLA_03_KEY);
            }
        }

        public bool Umbrella04
        {
            get
            {
                return CheckUmbrellaStatus(UMBRELLA_04_KEY);
            }
        }

        public bool Umbrella05
        {
            get
            {
                return CheckUmbrellaStatus(UMBRELLA_05_KEY);
            }
        }

        public bool Umbrella06
        {
            get
            {
                return CheckUmbrellaStatus(UMBRELLA_06_KEY);
            }
        }

        private bool IsUmbrellaKey(Key key)
        {
            return key == UMBRELLA_01_KEY ||
                   key == UMBRELLA_02_KEY ||
                   key == UMBRELLA_03_KEY ||
                   key == UMBRELLA_04_KEY ||
                   key == UMBRELLA_05_KEY ||
                   key == UMBRELLA_06_KEY;
        }

        private bool CheckUmbrellaStatus(Key key)
        {
            return (Keyboard.GetKeyStates(key) & KeyStates.Down) > 0;
        }

        private void KeyEventHandler(object sender, KeyEventArgs e)
        {
            if (IsUmbrellaKey(e.Key))
                OnUmbrellaKeyDown(e);
            else
                OnKeyDown(e);
        }

        protected virtual void OnUmbrellaKeyDown(KeyEventArgs args)
        {
            UmbrellaKeyDown handler = UmbrellaKeyDown;
            
            if (handler != null) 
                handler(this, args);
        }

        protected virtual void OnKeyDown(KeyEventArgs args)
        {
            KeyDown handler = KeyDown;
            if (handler != null) 
                handler(this, args);
        }

        private void KeyUpHandler(object sender, KeyEventArgs e)
        {
            if (IsUmbrellaKey(e.Key))
                OnUmbreallaKeyUp(e);
        }

        protected virtual void OnUmbreallaKeyUp(KeyEventArgs args)
        {
            UmbrellaKeyUp handler = UmbreallaKeyUp;
            if (handler != null) 
                handler(this, args);
        }
    }
}
