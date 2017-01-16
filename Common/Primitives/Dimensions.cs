﻿using Imagin.Common.Extensions;
using Imagin.Common.Input;
using System;
using System.Windows;

namespace Imagin.Common.Primitives
{
    /// <summary>
    /// Represents a size with binding support.
    /// </summary>
    [Serializable]
    public class Dimensions : AbstractObject, IVariant<Size>
    {
        #region Properties

        [field: NonSerialized]
        public event EventHandler<EventArgs<Size>> Changed;

        double width = 0d;
        public double Width
        {
            get
            {
                return width;
            }
            set
            {
                width = value.Coerce(double.MaxValue, 0d);
                OnChanged(Size);
                OnPropertyChanged("Width");
            }
        }

        double height = 0d;
        public double Height
        {
            get
            {
                return height;
            }
            set
            {
                height = value.Coerce(double.MaxValue, 0d);
                OnChanged(Size);
                OnPropertyChanged("Height");
            }
        }

        public Size Size
        {
            get
            {
                return new Size(width, height);
            }
        }

        #endregion

        #region Dimensions

        public Dimensions() : base()
        {
        }

        public Dimensions(Size Size) : base()
        {
            Set(Size);
        }

        public Dimensions(double Width, double Height) : base()
        {
            Set(Width, Height);
        }

        public static implicit operator Dimensions(Size Value)
        {
            return new Dimensions(Value);
        }

        #endregion

        #region Methods

        public Size Get()
        {
            return Size;
        }

        public void OnChanged(Size Value)
        {
            if (Changed != null)
                Changed(this, new EventArgs<Size>(Value));
        }

        public void Set(Size Size)
        {
            Set(Size.Width, Size.Height);
        }

        public void Set(double width, double height)
        {
            Width = width;
            Height = height;
        }

        public override string ToString()
        {
            return Size.ToString();
        }

        #endregion
    }
}