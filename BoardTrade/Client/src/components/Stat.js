import React from 'react'
import PropTypes from 'prop-types'
import styled from 'styled-components'
import ExchangeIcon from '../assets/img/ExchangeIcon'
import BinocularsIcon from '../assets/img/BinocularsIcon'
import UserIcon from '../assets/img/UserIcon'

export const StyledStatWrapper = styled.div`
  font-size: 12px;
  height: 20px;
  color: ${({ theme }) => theme.colors.greyDarkest};
  display: flex;
  align-items: center;
  svg {
    height: 12px;
    margin-right: 3px;
  }
`

const Stat = ({ number, type }) => {
  let icon
  switch (type) {
    case 'users':
      icon = <UserIcon />
      break
    case 'search':
      icon = <BinocularsIcon />
      break
    case 'exchange':
      icon = <ExchangeIcon />
      break
    default:
      icon = <UserIcon />
  }

  return (
    <StyledStatWrapper>
      {icon}
      <span>{number}</span>
    </StyledStatWrapper>
  )
}

Stat.propTypes = {
  number: PropTypes.number,
  type: PropTypes.oneOf(['users', 'search', 'exchange']).isRequired
}

Stat.defaultProps = {
  number: 0
}

export default Stat
