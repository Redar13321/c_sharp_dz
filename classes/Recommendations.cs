namespace ConsoleApp5.classes
{
    public static class Recommendations
    {
        public static bool CheckPost(SocialMediaPost post)
        {
            return post.Likes >= 2 * post.Dislikes;
        }
    }
}
