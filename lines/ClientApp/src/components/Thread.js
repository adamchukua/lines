import Post from "./Post"

export default function Thread() {
    return (
        <>
            <Post isThread={true} />
            <Post />
        </>
    );
}
