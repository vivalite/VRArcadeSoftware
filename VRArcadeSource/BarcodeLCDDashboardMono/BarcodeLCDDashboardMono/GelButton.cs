using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

class GelButton : Button
{

    #region Fields

    private bool enableFlashing = true;
    private Color gradientTop = Color.FromArgb(255, 44, 85, 177);
    private Color gradientBottom = Color.FromArgb(255, 153, 198, 241);
    private Color paintGradientTop;
    private Color paintGradientBottom;
    private Color paintForeColor;
    private Rectangle buttonRect;
    private Rectangle highlightRect;
    private int rectCornerRadius;
    private float rectOutlineWidth;
    private int highlightRectOffset;
    private int defaultHighlightOffset;
    private int highlightAlphaTop = 255;
    private int highlightAlphaBottom;
    private Timer animateButtonHighlightedTimer = new Timer();
    private Timer animateResumeNormalTimer = new Timer();
    private bool increasingAlpha;

    #endregion

    #region Properties

    [Category("Appearance")]
    [Description("The color to use for the top portion of the gradient fill of the component.")]
    [DefaultValue(typeof(Color), "0x2C55B1")]
    public Color GradientTop
    {
        get
        {
            return gradientTop;
        }
        set
        {
            gradientTop = value;
            SetPaintColors();
            Invalidate();
        }
    }

    [Category("Appearance")]
    [Description("The color to use for the bottom portion of the gradient fill of the component.")]
    [DefaultValue(typeof(Color), "0x99C6F1")]
    public Color GradientBottom
    {
        get
        {
            return gradientBottom;
        }
        set
        {
            gradientBottom = value;
            SetPaintColors();
            Invalidate();
        }
    }

    [Category("Appearance")]
    [Description("")]
    [DefaultValue(typeof(bool), "True")]
    public bool EnableFlashing
    {
        get
        {
            return enableFlashing;
        }
        set
        {
            enableFlashing = value;
        }
    }

    public override Color ForeColor
    {
        get
        {
            return base.ForeColor;
        }
        set
        {
            base.ForeColor = value;
            SetPaintColors();
            Invalidate();
        }
    }

    #endregion

    #region Initialization and Modification

    protected override void OnCreateControl()
    {
        SuspendLayout();
        SetControlSizes();
        SetPaintColors();
        InitializeTimers();
        base.OnCreateControl();
        ResumeLayout();
    }

    protected override void OnResize(EventArgs e)
    {
        SetControlSizes();
        this.Invalidate();
        base.OnResize(e);
    }

    private void SetControlSizes()
    {
        int scalingDividend = Math.Min(ClientRectangle.Width, ClientRectangle.Height);
        buttonRect = new Rectangle(ClientRectangle.X, ClientRectangle.Y,
  ClientRectangle.Width - 1, ClientRectangle.Height - 1);
        rectCornerRadius = Math.Max(1, scalingDividend / 10);
        rectOutlineWidth = Math.Max(1, scalingDividend / 50);
        highlightRect = new Rectangle(ClientRectangle.X, ClientRectangle.Y,
  ClientRectangle.Width - 1, (ClientRectangle.Height - 1) / 2);
        highlightRectOffset = Math.Max(1, scalingDividend / 35);
        defaultHighlightOffset = Math.Max(1, scalingDividend / 35);
    }

    protected override void OnEnabledChanged(EventArgs e)
    {
        if (!Enabled)
        {
            animateButtonHighlightedTimer.Stop();
            animateResumeNormalTimer.Stop();
        }
        SetPaintColors();
        Invalidate();
        base.OnEnabledChanged(e);
    }

    private void SetPaintColors()
    {
        if (Enabled)
        {
            if (SystemInformation.HighContrast)
            {
                paintGradientTop = Color.Black;
                paintGradientBottom = Color.Black;
                paintForeColor = Color.White;
            }
            else
            {
                paintGradientTop = gradientTop;
                paintGradientBottom = gradientBottom;
                paintForeColor = ForeColor;
            }
        }
        else
        {
            if (SystemInformation.HighContrast)
            {
                paintGradientTop = Color.Gray;
                paintGradientBottom = Color.White;
                paintForeColor = Color.Black;
            }
            else
            {
                int grayscaleColorTop = (int)(gradientTop.GetBrightness() * 255);
                paintGradientTop = Color.FromArgb(grayscaleColorTop,
      grayscaleColorTop, grayscaleColorTop);
                int grayscaleGradientBottom = (int)(gradientBottom.GetBrightness() * 255);
                paintGradientBottom = Color.FromArgb(grayscaleGradientBottom,
      grayscaleGradientBottom, grayscaleGradientBottom);
                int grayscaleForeColor = (int)(ForeColor.GetBrightness() * 255);
                if (grayscaleForeColor > 255 / 2)
                {
                    grayscaleForeColor -= 60;
                }
                else
                {
                    grayscaleForeColor += 60;
                }
                paintForeColor = Color.FromArgb(grayscaleForeColor, grayscaleForeColor, grayscaleForeColor);
            }
        }
    }

    private void InitializeTimers()
    {
        animateButtonHighlightedTimer.Interval = 20;
        animateButtonHighlightedTimer.Tick += new EventHandler(animateButtonHighlightedTimer_Tick);
        animateResumeNormalTimer.Interval = 5;
        animateResumeNormalTimer.Tick += new EventHandler(animateResumeNormalTimer_Tick);
    }

    #endregion

    #region Custom Painting

    protected override void OnPaint(PaintEventArgs pevent)
    {
        Graphics g = pevent.Graphics;
        ButtonRenderer.DrawParentBackground(g, ClientRectangle, this);
        // Paint the outer rounded rectangle
        g.SmoothingMode = SmoothingMode.AntiAlias;
        using (GraphicsPath outerPath = RoundedRectangle(buttonRect, rectCornerRadius, 0))
        {
            using (LinearGradientBrush outerBrush = new LinearGradientBrush(buttonRect,
    paintGradientTop, paintGradientBottom, LinearGradientMode.Vertical))
            {
                g.FillPath(outerBrush, outerPath);
            }
            using (Pen outlinePen = new Pen(paintGradientTop, rectOutlineWidth))
            {
                outlinePen.Alignment = PenAlignment.Inset;
                g.DrawPath(outlinePen, outerPath);
            }
        }
        // If this is the default button, paint an additional highlight
        if (IsDefault)
        {
            using (GraphicsPath defaultPath = new GraphicsPath())
            {
                defaultPath.AddPath(RoundedRectangle(buttonRect, rectCornerRadius, 0), false);
                defaultPath.AddPath(RoundedRectangle(buttonRect, rectCornerRadius, defaultHighlightOffset), false);
                using (PathGradientBrush defaultBrush = new PathGradientBrush(defaultPath))
                {
                    defaultBrush.CenterColor = Color.FromArgb(50, Color.White);
                    defaultBrush.SurroundColors = new Color[] { Color.FromArgb(100, Color.White) };
                    g.FillPath(defaultBrush, defaultPath);
                }
            }
        }
        // Paint the gel highlight
        using (GraphicsPath innerPath = RoundedRectangle(highlightRect, rectCornerRadius, highlightRectOffset))
        {
            using (LinearGradientBrush innerBrush = new LinearGradientBrush(highlightRect,
    Color.FromArgb(highlightAlphaTop, Color.White),
    Color.FromArgb(highlightAlphaBottom, Color.White), LinearGradientMode.Vertical))
            {
                g.FillPath(innerBrush, innerPath);
            }
        }
        // Paint the text
        TextRenderer.DrawText(g, Text, Font, buttonRect, paintForeColor, Color.Transparent,
  TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis);
    }

    private static GraphicsPath RoundedRectangle(Rectangle boundingRect, int cornerRadius, int margin)
    {
        GraphicsPath roundedRect = new GraphicsPath();
        roundedRect.AddArc(boundingRect.X + margin, boundingRect.Y + margin, cornerRadius * 2,
  cornerRadius * 2, 180, 90);
        roundedRect.AddArc(boundingRect.X + boundingRect.Width - margin - cornerRadius * 2,
  boundingRect.Y + margin, cornerRadius * 2, cornerRadius * 2, 270, 90);
        roundedRect.AddArc(boundingRect.X + boundingRect.Width - margin - cornerRadius * 2,
  boundingRect.Y + boundingRect.Height - margin - cornerRadius * 2, cornerRadius * 2, cornerRadius * 2, 0, 90);
        roundedRect.AddArc(boundingRect.X + margin,
  boundingRect.Y + boundingRect.Height - margin - cornerRadius * 2,
  cornerRadius * 2, cornerRadius * 2, 90, 90);
        roundedRect.AddLine(boundingRect.X + margin,
  boundingRect.Y + boundingRect.Height - margin - cornerRadius * 2,
  boundingRect.X + margin, boundingRect.Y + margin + cornerRadius);
        roundedRect.CloseFigure();
        return roundedRect;
    }

    #endregion

    #region Mouse and Keyboard Interaction

    protected override void OnMouseEnter(EventArgs e)
    {
        HighlightButton();
        base.OnMouseEnter(e);
    }

    protected override void OnGotFocus(EventArgs e)
    {
        HighlightButton();
        base.OnGotFocus(e);
    }

    private void HighlightButton()
    {
        if (Enabled && enableFlashing)
        {
            animateResumeNormalTimer.Stop();
            animateButtonHighlightedTimer.Start();
        }
    }

    private void animateButtonHighlightedTimer_Tick(object sender, EventArgs e)
    {
        if (increasingAlpha)
        {
            if (100 <= highlightAlphaBottom)
            {
                increasingAlpha = false;
            }
            else
            {
                highlightAlphaBottom += 5;
            }
        }
        else
        {
            if (0 >= highlightAlphaBottom)
            {
                increasingAlpha = true;
            }
            else
            {
                highlightAlphaBottom -= 5;
            }
        }
        Invalidate();
    }

    protected override void OnMouseLeave(EventArgs e)
    {
        ResumeNormalButton();
        base.OnMouseLeave(e);
    }

    protected override void OnLostFocus(EventArgs e)
    {
        ResumeNormalButton();
        base.OnLostFocus(e);
    }

    private void ResumeNormalButton()
    {
        if (Enabled)
        {
            animateButtonHighlightedTimer.Stop();
            animateResumeNormalTimer.Start();
        }
    }

    private void animateResumeNormalTimer_Tick(object sender, EventArgs e)
    {
        bool modified = false;
        if (highlightAlphaBottom > 0)
        {
            highlightAlphaBottom -= 5;
            modified = true;
        }
        if (highlightAlphaTop < 255)
        {
            highlightAlphaTop += 5;
            modified = true;
        }
        if (!modified)
        {
            animateResumeNormalTimer.Stop();
        }
        Invalidate();
    }

    protected override void OnMouseDown(MouseEventArgs mevent)
    {
        PressButton();
        base.OnMouseDown(mevent);
    }

    protected override void OnKeyDown(KeyEventArgs kevent)
    {
        if (kevent.KeyCode == Keys.Space || kevent.KeyCode == Keys.Return)
        {
            PressButton();
        }
        base.OnKeyDown(kevent);
    }

    private void PressButton()
    {
        if (Enabled)
        {
            animateButtonHighlightedTimer.Stop();
            animateResumeNormalTimer.Stop();
            highlightRect.Location = new Point(0, ClientRectangle.Height / 2);
            highlightAlphaTop = 0;
            highlightAlphaBottom = 200;
            Invalidate();
        }
    }

    protected override void OnMouseUp(MouseEventArgs mevent)
    {
        ReleaseButton();
        if (DisplayRectangle.Contains(mevent.Location))
        {
            HighlightButton();
        }
        base.OnMouseUp(mevent);
    }

    protected override void OnKeyUp(KeyEventArgs kevent)
    {
        if (kevent.KeyCode == Keys.Space || kevent.KeyCode == Keys.Return)
        {
            ReleaseButton();
            if (IsDefault)
            {
                HighlightButton();
            }
        }
        base.OnKeyUp(kevent);
    }

    protected override void OnMouseMove(MouseEventArgs mevent)
    {
        if (Enabled && (mevent.Button & MouseButtons.Left) == MouseButtons.Left &&
  !ClientRectangle.Contains(mevent.Location))
        {
            ReleaseButton();
        }
        base.OnMouseMove(mevent);
    }

    private void ReleaseButton()
    {
        if (Enabled)
        {
            highlightRect.Location = new Point(0, 0);
            highlightAlphaTop = 255;
            highlightAlphaBottom = 0;
        }
    }

    #endregion

}