import Post from "./Post"

export default function Thread({ isFullThread }) {
    return (
        <>
            <Post isThread={true} />
            <Post isThread={isFullThread} />
        </>
    );
}
