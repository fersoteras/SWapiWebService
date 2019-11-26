namespace WebApiService.Helpers
{
    public interface IRatingService
    {
        public float GetAvgRating(int id);
        public  int GetMaxRating(int id);
    }
       
}