export default function DataDisplay({ status, error, children, isInfiniteScroll }) {
    if (status === 'loading' || error === 'Request failed with status code 404') {
        if (isInfiniteScroll) {
            return (
                <>
                    {children}

                    {!error && (
                        <progress className="progress is-medium is-dark mt-4" max="100">45%</progress>
                    )}
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