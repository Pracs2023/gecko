using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace PuppyBox
{
  
    public class Box
    {
        // public Point Position { get; set; }
        public int BoxIndex = -1;
        public int Height = 10;
        public int Width = 10;
        public int Top = 0;
        public int Left = 0;
        public event EventHandler Click;
        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle(Left, Top, Width, Height);
            }
        }
        public void RaiseClickEvent()
        {
            Click?.Invoke(this, null);
        }
        public Boolean IsDog { get; set; }
        public static string BoxImagePath = Utility.FileUtility.PuppyFilePath;
        
        private static Bitmap _DogImage = null;
        private Bitmap DogImage
        {
            get
            {

                if (_DogImage == null)
                {
                   _DogImage = (Bitmap)Image.FromFile(BoxImagePath );
                }
                return _DogImage;
            }
        }
        public static Color BackBoxColor = Color.Teal  ;
        public static Color FaceBoxColor = Color.LightYellow ;
        private static Brush _BackBrush = null;
        private  Brush BackBrush
        {
            get
            {
                if(_BackBrush ==null)
                {
                    _BackBrush = new SolidBrush(BackBoxColor);
                }
                return _BackBrush;
            }
        }

        private static Brush _FaceBrushEmpty = null;
        private Brush FaceBrushEmpty
        {
            get
            {
                if (_FaceBrushEmpty == null)
                {
                    //Brush BackBrush = new SolidBrush(Color.Teal);
                    _FaceBrushEmpty = new SolidBrush(FaceBoxColor);
                }
                return _FaceBrushEmpty;
            }
        }
        public Box Clone()
        {
            Box newBox = new Box();
            newBox.Top = this.Top;
            newBox.Left = this.Left;
            newBox.Width = this.Width;
            newBox.Height = this.Height;
            newBox.IsDog = this.IsDog;
            newBox.BoxIndex = this.BoxIndex;
          //  newBox.IsReveal = this.IsReveal;
            return newBox;
        }
        public enum BoxStateEnum
        {
            Close,
            BegintoOpen1,
            BegintoOpen2,
            BegintoOpen3,
            Open
        }
        public BoxStateEnum BoxState { get;  set; }

        private Point TopLeftPoint
        {
            get
            {
                return new Point(Left - 1, Top + 1);
            }
        }
        private Point TopRightPoint
        {
            get
            {
                return new Point(this.Left + this.Width - 2, this.Top + this.Top + 1);
            }
        }
        private Point BottomLeftPoint
        {
            get
            {
                return new Point(Left - 1, this.Top + this.Height - 2);
            }
        }
        private Point BottomRightPoint
        {
            get
            {
                return new Point(this.Left + this.Width - 2, this.Top + this.Height - 2);
            }
        }

        private void DrawClose(Graphics g)
        {
            Rectangle FillArea = new Rectangle(new Point(Left , Top ), new Size(Width - 2, Height - 2));
            g.FillRectangle(BackBrush, FillArea);
            List<Point> listPoint = new List<Point>();



            Point LeftSideTopLeft = new Point(TopLeftPoint.X - this.BoxLength , TopLeftPoint.Y + this.BoxLength);
            Point LeftSideBottomLeft = new Point(LeftSideTopLeft.X, LeftSideTopLeft.Y + this.Height);


            listPoint.Add(TopLeftPoint);
            listPoint.Add(LeftSideTopLeft);
            listPoint.Add(LeftSideBottomLeft);
            listPoint.Add(BottomLeftPoint );



            g.FillPolygon(BackBrush, listPoint.ToArray());
            listPoint.Clear();
            Point DownSideBottomLeft = LeftSideBottomLeft;
            Point DownSideBottomRight = new Point(LeftSideBottomLeft.X + this.Width, DownSideBottomLeft.Y);
            Point DownSideTopRight = BottomRightPoint; // new Point(this.Width + this.Left, this.Height + this.Top);


            listPoint.Add(BottomLeftPoint);
            listPoint.Add(DownSideBottomLeft);
            listPoint.Add(DownSideBottomRight );
            listPoint.Add(DownSideTopRight );

            g.FillPolygon(BackBrush, listPoint.ToArray());
        }
        int BoxLength = 10;
       
        private void DrawBeginToOpen1(Graphics g)
        {
            Point TopLeftCustom = new Point(TopLeftPoint.X - 10, TopLeftPoint.Y + 10);
            Point BottomLeftCustom = new Point(TopLeftCustom.X, TopLeftCustom.Y + this.Height);
            Point TopRightCustom = new Point(TopLeftPoint.X + this.Width -10, TopLeftCustom.Y - 30);
            Point BottomRightCustom = new Point(TopLeftPoint.X + this.Width - 10, TopRightCustom.Y +this.Height );
            List<Point> listPoint = new List<Point>();

            listPoint.Add(TopLeftCustom);
            listPoint.Add(BottomLeftCustom);
            listPoint.Add(BottomRightCustom);
            listPoint.Add(TopRightCustom);
            g.FillPolygon(BackBrush, listPoint.ToArray());

            Point DownSideBottomLeft = new Point(BottomLeftCustom.X + 10, BottomLeftCustom.Y + 10);
            Point DownSideBottomRight = new Point(BottomRightCustom.X + 10, BottomRightCustom.Y + 10);
            listPoint = new List<Point>();
            listPoint.Add(BottomLeftCustom);
            listPoint.Add(DownSideBottomLeft);
            listPoint.Add(DownSideBottomRight);
            listPoint.Add(BottomRightCustom);
            g.FillPolygon(BackBrush, listPoint.ToArray());
            
            Point RightSideTopRight = new Point(TopRightCustom.X + 10, TopRightCustom.Y + 10);
            Point RightSideBottomRight = new Point(BottomRightCustom.X + 10, BottomRightCustom.Y + 10);
            listPoint = new List<Point>();
            listPoint.Add(TopRightCustom);
            listPoint.Add(RightSideTopRight);
            listPoint.Add(RightSideBottomRight);
            listPoint.Add(BottomRightCustom);
            g.FillPolygon (BackBrush, listPoint.ToArray());
            


        }
       
        private void DrawBeginToOpen2(Graphics g)
        {

            Point TopLeftCustom = new Point(TopLeftPoint.X + BoxLength, TopLeftPoint.Y + BoxLength);
            Point BottomLeftCustom = new Point(TopLeftCustom.X, TopLeftCustom.Y + this.Height);
            Point TopRightCustom = new Point(TopLeftPoint.X + (this.Width/2) - 10, TopLeftCustom.Y - (this.Height /2));
            Point BottomRightCustom = new Point(TopLeftPoint.X + (this.Width/2) - 10, TopRightCustom.Y + this.Height);
            List<Point> listPoint = new List<Point>();

            listPoint.Add(TopLeftCustom);
            listPoint.Add(BottomLeftCustom);
            listPoint.Add(BottomRightCustom);
            listPoint.Add(TopRightCustom);
            g.FillPolygon(BackBrush, listPoint.ToArray());

            Point DownSideBottomLeft = new Point(BottomLeftCustom.X + BoxLength, BottomLeftCustom.Y);
            Point DownSideBottomRight = new Point(BottomRightCustom.X + BoxLength, BottomRightCustom.Y);
            listPoint = new List<Point>();
            listPoint.Add(BottomLeftCustom);
            listPoint.Add(DownSideBottomLeft);
            listPoint.Add(DownSideBottomRight);
            listPoint.Add(BottomRightCustom);
            g.FillPolygon(BackBrush, listPoint.ToArray());

            Point RightSideTopRight = new Point(TopRightCustom.X + BoxLength , TopRightCustom.Y);
            Point RightSideBottomRight = new Point(BottomRightCustom.X + BoxLength , BottomRightCustom.Y );
            listPoint = new List<Point>();
            listPoint.Add(TopRightCustom);
            listPoint.Add(RightSideTopRight);
            listPoint.Add(RightSideBottomRight);
            listPoint.Add(BottomRightCustom);
            g.FillPolygon(BackBrush, listPoint.ToArray());
        }
        private void DrawBeginToOpen3(Graphics g)
        {
            Point TopLeftCustom = new Point(TopLeftPoint.X + 20, TopLeftPoint.Y - 20);
            Point BottomLeftCustom = new Point(TopLeftCustom.X, TopLeftCustom.Y + this.Height);
            Point TopRightCustom = new Point(TopLeftPoint.X + this.Width - 20, TopLeftCustom.Y +this.BoxLength );
            Point BottomRightCustom = new Point(TopRightCustom.X , TopRightCustom.Y + this.Height);
            List<Point> listPoint = new List<Point>();

            listPoint.Add(TopLeftCustom);
            listPoint.Add(BottomLeftCustom);
            listPoint.Add(BottomRightCustom);
            listPoint.Add(TopRightCustom);
            g.FillPolygon(FaceBrushEmpty, listPoint.ToArray());

            Point LeftSideTopLeft = new Point(TopLeftCustom.X - BoxLength , TopLeftCustom.Y + this.BoxLength);
            Point LeftSideBottomLeft = new Point(LeftSideTopLeft.X , LeftSideTopLeft.Y + this.Height  );
            listPoint = new List<Point>();
            listPoint.Add(TopLeftCustom );
            listPoint.Add(LeftSideTopLeft);
            listPoint.Add(LeftSideBottomLeft);
            listPoint.Add(BottomLeftCustom);
            g.FillPolygon(BackBrush, listPoint.ToArray());

           // Point DownSideTopRight = new Point(TopRightCustom.X + 10, TopRightCustom.Y + 10);
            Point DownSideBottomRight = new Point(BottomRightCustom.X - BoxLength, BottomRightCustom.Y + BoxLength );
            listPoint = new List<Point>();
            listPoint.Add(BottomLeftCustom);
            listPoint.Add(LeftSideBottomLeft);
            listPoint.Add(DownSideBottomRight);
            listPoint.Add(BottomRightCustom);
            g.FillPolygon(BackBrush, listPoint.ToArray());

        }
        private void DrawOpen(Graphics g)
        {
            DrawClose(g);
            Rectangle FillArea = new Rectangle(new Point(Left + 1, Top + 1), new Size(Width - 2, Height - 2));

            g.FillRectangle(BackBrush, FillArea);
            if (IsDog)
            {
                g.DrawImage(DogImage, FillArea);
            }
            else
            {
                g.FillRectangle(FaceBrushEmpty, FillArea);
            }

        }
        public delegate void DrawFunction(Graphics g);

        // private delegate DrawFunction(Graphics g);
        private  Dictionary<BoxStateEnum, DrawFunction> _DictionaryAction = null;
        private  Dictionary<BoxStateEnum, DrawFunction> DictionaryAction
        {
            get
            {
                if (_DictionaryAction == null)
                {
                    _DictionaryAction = new Dictionary<BoxStateEnum, DrawFunction>();

                    _DictionaryAction.Add(BoxStateEnum.Close, DrawClose);
                    _DictionaryAction.Add(BoxStateEnum.BegintoOpen1, DrawBeginToOpen1);
                    _DictionaryAction.Add(BoxStateEnum.BegintoOpen2, DrawBeginToOpen2);
                    _DictionaryAction.Add(BoxStateEnum.BegintoOpen3, DrawBeginToOpen3);
                    _DictionaryAction.Add(BoxStateEnum.Open, DrawOpen);
                }
                return _DictionaryAction;
            }
        }
        public void Draw(Graphics g)
        {
            /*
            Pen pen = new Pen(new SolidBrush(Color.Black ), 2);
            Pen pen2 =new Pen(new SolidBrush(Color.Black ), 2f);
            Pen pen3 = new Pen(new SolidBrush(Color.Black  ), 2f);
            Rectangle DrawArea = new Rectangle(new Point (Left,Top), new Size(Width, Height));
           Brush BackBrush = new SolidBrush(Color.Teal);
            Brush FaceBrushEmpty = new SolidBrush(Color.WhiteSmoke  );
            */


            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            DictionaryAction[this.BoxState].DynamicInvoke(new object[] { g });
            /*
            switch (this.BoxState )
            {
                case BoxStateEnum.Close:
                    DrawClose(g);
                    break;
                case BoxStateEnum.BegintoOpen1:

                    break;
                case BoxStateEnum.BegintoOpen2:
                    break;
                case BoxStateEnum.BegintoOpen3:
                    break;
                case BoxStateEnum.Open:
                    DrawOpen(g);
                    break;
                default:
                    throw new Exception(String.Format("BoxState is {0} which is invalid ", this.BoxState));
            }
            */

            /*
            g.FillRectangle(BackBrush, FillArea );
            if(IsReveal)
            {
                if(IsDog )
                {
                    g.DrawImage(DogImage, DrawArea);
                }
                else
                {
                    g.FillRectangle(FaceBrushEmpty, FillArea);
                }
            }
            */


          //  return;

          


        }


    }
}
