import Post from "../../common/Post";
import Thread from "../../common/Thread";

export default function PostsList({ posts }) {
    return (
        <>
            {posts && posts.map((post) => (
                <div className="box post" key={post.id}>
                    <Post post={post} />
                </div>    
            ))}
        </>
    );
}
