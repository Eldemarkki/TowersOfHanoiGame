namespace TowerOfHanoi.Printers
{
    class PrettyGamePrinter : StylisedPrinter
    {
        public override void Print(TowerOfHanoiGame game, PrintStyleSettings printStyleSettings)
        {
            Print(game, printStyleSettings, '-', '|', '-', '-', '-', '-', '-', '-');
        }
    }
}
