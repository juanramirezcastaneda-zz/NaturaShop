const requestCustomersType = "REQUEST_CUSTOMERS";
const receiveCustomersType = "RECEIVE_CUSTOMERS";
const initialState = { customers: [], isLoading: false };

export const actionCreators = {
  requestCustomers: () => async (dispatch, getState) => {
    dispatch({ type: requestCustomersType });

    const url = `api/Customers`;
    const response = await fetch(url);
    const customers = await response.json();

    dispatch({ type: receiveCustomersType, customers });
  }
};
export const reducer = (state, action) => {
  state = state || initialState;

  if (action.type === requestCustomersType) {
    return {
      ...state,
      isLoading: true
    };
  }
  if (action.type === receiveCustomersType) {
    return {
      ...state,
      customers: action.customers,
      isLoading: false
    };
  }
  return state;
};
