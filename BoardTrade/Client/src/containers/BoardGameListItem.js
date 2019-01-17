import React, { Component } from 'react'
import { connect } from 'react-redux'
import PropTypes from 'prop-types'
import ListItem from '../components/ListItem'
import {
  getBoardGameThumbnailUrl,
  getBoardGameName,
  getBoardGameDescription
} from '../selectors/boardGameSelector'

export class BoardGameListItem extends Component {
  static propTypes = {
    id: PropTypes.string.isRequired
  }

  render() {
    const {
      props: { name, description, thumbnailUrl }
    } = this
    return (
      <ListItem
        thumbnail={thumbnailUrl}
        name={name}
        description={description}
      />
    )
  }
}

const mapStateToProps = (state, { id }) => ({
  name: getBoardGameName(state, id),
  description: getBoardGameDescription(state, id),
  thumbnailUrl: getBoardGameThumbnailUrl(state, id)
})

export default connect(mapStateToProps)(BoardGameListItem)
