import Post from "../../common/Post";
import Thread from "../../common/Thread";

export default function PostsList({ posts }) {
    const findReply = (post) => {
        return posts.find(p => p.repliedPostId == post.id);
    }

    const findOriginalPost = (reply) => {
        return posts.find(p => p.id == reply.repliedPostId);
    }

    return (
        <>
            {posts && posts.map((post, index) => (
                <>
                    {findReply(post) ? (
                        <Thread posts={[post, findReply(post)]} />    
                    ) : (
                        <>
                            {findOriginalPost(post) ? (
                                <Thread posts={[findOriginalPost(post), post]} />
                            ) : (
                                <Post post={post} />
                            )}
                        </>
                    )}
                </>
            ))}
        </>
    );
}
