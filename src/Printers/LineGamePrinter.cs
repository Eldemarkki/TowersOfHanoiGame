namespace TowerOfHanoi.Printers
{
    class LineGamePrinter : StylisedPrinter
    {
        public override void Print(TowerOfHanoiGame game, PrintStyleSettings printStyleSettings)
        {
            Print(game, printStyleSettings, '─', '│', '┌', '┐', '└', '┘', '┴', '┬');
        }
    }
}
