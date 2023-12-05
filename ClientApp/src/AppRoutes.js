import { Counter } from "./components/Counter";
import { FetchData } from "./components/FetchData";
import { Home } from "./components/Home";
import { TableManager } from "./components/TableManagment/TableManager";
import ExperementForm  from './components/ReactExperementPage/ReactExperemetComponent';
const AppRoutes = [
  {
    index: true,
    element: <Home />
  },
  {
    path: '/counter',
    element: <Counter />
  },
  {
    path: '/fetch-data',
    element: <FetchData />
  },
  {
    path: '/table-manager',
    element: <TableManager />
  },
  {
    path: '/Experemets',
    element: <ExperementForm />
  },
  {
    path: '/Fetch',
    element: <FetchData />
  }


  
];

export default AppRoutes;
