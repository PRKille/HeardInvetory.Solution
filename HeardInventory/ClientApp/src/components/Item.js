import React from 'react';
import PropTypes from 'prop-types';

function Item(props) {
  return (
    <React.Fragment>
      <h1>{props.itemName}</h1>
      <ul>
        <li>Category: {props.category}</li>
        <li>Vendor: {props.vendor}</li>
        <li>Purchase Info: ${props.purchasePrice}/{props.purchaseQuantity}{props.purchaseQuantityType}</li>
        <li>Last Inventory: {props.startingInventory} {props.purchaseQuantityType}</li>
      </ul>
    </React.Fragment>
  )
}

Item.propTypes = {
  itemName: PropTypes.string,
  category: PropTypes.string,
  vendor: PropTypes.string,
  purchasePrice: PropTypes.number,
  purchaseQuantity: PropTypes.number,
  purchaseQuantityType: PropTypes.string,
  startingInventory: PropTypes.number,
  itemId: PropTypes.itemId
}

export default Item;