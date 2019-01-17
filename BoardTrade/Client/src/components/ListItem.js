import React from 'react'
import PropTypes from 'prop-types'
import styled from 'styled-components'
import Paper from './Paper'
import Thumbnail from './Thumbnail'
import Link from './Link'
import Stat from './Stat'

export const StyledListItemWrapper = styled(Paper)`
  display: grid;
  max-height: 160px;
  grid-template-columns: 100px minmax(auto, 1fr);
  grid-template-rows: auto auto 1fr;
  grid-template-areas: 'thumbnail title' 'thumbnail stats' 'thumbnail description';
  grid-gap: 0px 8px;
`

const StyledThumbnail = styled(Thumbnail)`
  grid-area: thumbnail;
`

const StyledStatsWrapper = styled.div`
  grid-area: stats;
  display: flex;
  div {
    margin-right: 8px;
  }
`

const StyledDescriptionWrapper = styled.span`
  padding-top: 8px;
  overflow: hidden;
  text-overflow: ellipsis;
  grid-area: description;
  max-height: 98px;
  -webkit-line-clamp: 3;
  -webkit-box-orient: vertical;
`

const ListItem = ({ name, description, thumbnail }) => {
  return (
    <StyledListItemWrapper>
      <StyledThumbnail src={thumbnail} />
      <Link>{name}</Link>
      <StyledStatsWrapper>
        <Stat number={123123} type={'users'} />
        <Stat number={123123} type={'search'} />
        <Stat number={123123} type={'exchange'} />
      </StyledStatsWrapper>
      <StyledDescriptionWrapper>{description}</StyledDescriptionWrapper>
    </StyledListItemWrapper>
  )
}

ListItem.propTypes = {
  name: PropTypes.string,
  description: PropTypes.string,
  thumbnail: PropTypes.string
}

export default ListItem
