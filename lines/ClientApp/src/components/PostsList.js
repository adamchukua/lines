import Post from "./Post";
import Thread from "./Thread";

export default function PostsList() {
    return (
        <div>
            <div className="box post">
                <Post />
            </div>

            <div className="box post">
                <Thread />
            </div>

            <div className="box post">
                <Post />
            </div>
        </div>
    );
}
