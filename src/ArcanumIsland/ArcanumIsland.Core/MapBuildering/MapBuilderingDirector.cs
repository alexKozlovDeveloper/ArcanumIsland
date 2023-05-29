namespace ArcanumIsland.Core.MapBuildering
{
    public class MapBuilderingDirector
    {
        private IMap _currentMap;

        public MapBuilderingDirector(int width, int height)
        {
            _currentMap = new Map(width, height);
        }

        public TResult ApplyStepBuilder<TParameters, TResult>(StepBuilderBase<TParameters, TResult> stepBuilder) 
            where TParameters : IStepBuilderParams
            where TResult : IStepBuilderResult
        {
            return stepBuilder.Aplly(_currentMap);
        }

        public IMap GetMap() 
        {
            return _currentMap;
        }
    }
}
