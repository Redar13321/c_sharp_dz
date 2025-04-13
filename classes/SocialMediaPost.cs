namespace ConsoleApp5.classes
{
    public class SocialMediaPost
    {
        public int Id { get; set; }
        public int Likes { get; set; }
        public int Dislikes { get; set; }
        public string Message { get; set; }

        public static SocialMediaPost operator +(SocialMediaPost post, int likes)
        {
            post.Likes += likes;
            return post;
        }

        public static SocialMediaPost operator -(SocialMediaPost post, int dislikes)
        {
            post.Dislikes += dislikes;
            return post;
        }

        public static SocialMediaPost operator ++(SocialMediaPost post)
        {
            post.Likes++;
            return post;
        }

        public static SocialMediaPost operator --(SocialMediaPost post)
        {
            post.Dislikes++;
            return post;
        }
    }
}
