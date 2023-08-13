import DataDisplay from "../../common/DataDisplay";
import Post from "../../common/Post";
import Thread from "../../common/Thread";

export default function PostsList({ posts }) {
    const findOriginalPost = (reply) => {
        return posts.posts.find(p => p.id == reply.repliedPostId);
    }

    return (
        <DataDisplay status={posts.status} error={posts.error}>
            {posts.posts.map((post) => (
                <>
                    {findOriginalPost(post) ? (
                        <Thread posts={[findOriginalPost(post), post]} />
                    ) : (
                        <Post post={post} />
                    )}
                </>
            ))}
        </DataDisplay>
    );
}
