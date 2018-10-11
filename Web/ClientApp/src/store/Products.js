const requestProductsType = "REQUEST_PARTNERS";
const receiveProductsType = "RECEIVE_PARTNERS";
const initialState = { products: [], isLoading: false };

export const actionCreators = {
  requestProducts: () => async (dispatch, getState) => {
    dispatch({ type: requestProductsType });

    const url = `api/Products`;
    const response = await fetch(url);
    const products = await response.json();

    dispatch({ type: receiveProductsType, products });
  }
};
export const reducer = (state, action) => {
  state = state || initialState;

  switch (action.type) {
    case requestProductsType:
      return {
        ...state,
        isLoading: true
      };
    case receiveProductsType:
      return {
        ...state,
        products: action.products,
        isLoading: false
      };
    default:
      return state;
  }
};
