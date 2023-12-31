import { Route, Routes } from 'react-router-dom';
import AppRoutes from './AppRoutes';
import Layout from '../common/Layout';
import '../main.css';

export default function App() {
    return (
        <Layout>
            <Routes>
                {AppRoutes.map((route, index) => {
                    const { element, ...rest } = route;
                    return <Route key={index} {...rest} element={element} />;
                })}
            </Routes>
        </Layout>
    );
}
