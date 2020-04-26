namespace TowerOfHanoi.Printers
{
    class PipeGamePrinter : StylisedPrinter
    {
        public override void Print(TowerOfHanoiGame game, PrintStyleSettings printStyleSettings)
        {
            Print(game, printStyleSettings, '═', '║', '╔', '╗', '╚', '╝', '╩', '╦');
        }
    }
}
