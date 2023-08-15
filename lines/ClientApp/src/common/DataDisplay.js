export default function DataDisplay({ status, error, children, isInfiniteScroll }) {
    if (status === 'loading') {
        if (isInfiniteScroll) {
            return (
                <>
                    {children}

                    <progress className="progress is-medium is-dark mt-4" max="100">45%</progress>
                </>
            );
        }

        return (
            <progress className="progress is-medium is-dark" max="100">45%</progress>
        );
    } else if (status === 'failed') {
        return <>Error: {error}</>;
    } else {
        return <>{children}</>;
    }
};