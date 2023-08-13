export default function DataDisplay({ status, error, children }) {
    if (status === 'loading') {
        return (
            <progress class="progress is-medium is-dark" max="100">45%</progress>
        );
    } else if (status === 'failed') {
        return <>Error: {error}</>;
    } else {
        return <>{children}</>;
    }
};