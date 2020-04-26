namespace TowerOfHanoi.Printers
{
    public struct PrintStyleSettings
    {
        public int HorizontalPadding { get; set; }
        public int VerticalPadding { get; set; }

        public PrintStyleSettings(int horizontalPadding, int verticalPadding)
        {
            HorizontalPadding = horizontalPadding;
            VerticalPadding = verticalPadding;
        }

    }
}
