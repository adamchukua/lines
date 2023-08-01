import PostsList from "./PostsList";
import Post from "./Post";
import Thread from "./Thread";
import ReplyInput from "./ReplyInput";

export default function PostPage() {
    return (
        <>
            <Thread isFullThread={true} />

            <div style={{ fontSize: "1.2rem" }} className="py-5">
                <Post />
            </div>

            <ReplyInput />

            <PostsList />
        </>
    );
}
