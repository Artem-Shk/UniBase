import { createStore,applyMiddleware} from 'redux';
import thunk  from 'redux-thunk';
import rootReducer from './reducers';
import { fetchStudentsData } from './actions';


let store = createStore(rootReducer,applyMiddleware(thunk))
console.log(store.getState())
const unsubscribe = store.subscribe(() => console.log(store.getState()))
store.dispatch(fetchStudentsData('Алексей'))  
export default store;