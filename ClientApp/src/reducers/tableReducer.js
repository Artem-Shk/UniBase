import { ERROR, fetchStudentsData, GET_JSON_BY_NAME } from "../actions";

//table reducer save state of table
const initialState = {
  data: [],
  name: '',
};
function toTable(state = initialState, action) {
  switch (action.type) {
    case GET_JSON_BY_NAME:
      return { ...state, data: action.payload};
    case ERROR:
      if(action.Error_code === 204)
      {
        return {...state,status: action.Error_code};
      }
    default:
      return state;
  }
}
export default toTable;