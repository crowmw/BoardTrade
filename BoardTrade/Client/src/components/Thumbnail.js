import styled from 'styled-components'

export const Thumbnail = styled.img`
  max-height: 250px;
  max-width: 250px;
  min-width: 100px;
  /* height: 100px; */
  width: 100px;
  object-fit: contain;
  outline: none;

  :hover {
    border: ${({ theme }) => theme.colors.blueLight};
    cursor: pointer;
  }
`

export default Thumbnail
