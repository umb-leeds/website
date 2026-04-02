export default async function handler(req, res) {
  const url = 'https://api.meetup.com/gql';
  const query = `
    query {
      groupByUrlname(urlname: "umbLeeds") {
        upcomingEvents(input: { first: 5 }) {
          edges {
            node {
              title
              dateTime
              eventUrl
              venue {
                name
                address
                city
              }
              going
              maxTickets
            }
          }
        }
        pastEvents(input: { first: 5 }) {
          edges {
            node {
              title
              dateTime
              eventUrl
              venue {
                name
                address
                city
              }
              going
            }
          }
        }
      }
    }
  `;

  try {
    const response = await fetch(url, {
      method: 'POST',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify({ query }),
    });

    if (!response.ok) {
      throw new Error('Meetup API returned ' + response.status);
    }

    const data = await response.json();
    const group = data.data.groupByUrlname;

    const upcoming = (group.upcomingEvents.edges || []).map(function(e) {
      return formatEvent(e.node, true);
    });

    const past = (group.pastEvents.edges || []).map(function(e) {
      return formatEvent(e.node, false);
    });

    res.setHeader('Cache-Control', 's-maxage=300, stale-while-revalidate=600');
    res.setHeader('Access-Control-Allow-Origin', '*');
    res.json({ upcoming: upcoming, past: past });
  } catch (err) {
    res.status(500).json({ error: err.message, upcoming: [], past: [] });
  }
}

function formatEvent(node, isUpcoming) {
  var dt = new Date(node.dateTime);
  var days = ['Sunday','Monday','Tuesday','Wednesday','Thursday','Friday','Saturday'];
  var months = ['January','February','March','April','May','June','July','August','September','October','November','December'];

  return {
    title: node.title,
    date: days[dt.getDay()] + ' ' + dt.getDate() + ' ' + months[dt.getMonth()] + ' ' + dt.getFullYear(),
    time: dt.toLocaleTimeString('en-GB', { hour: '2-digit', minute: '2-digit' }),
    venue: node.venue ? node.venue.name : 'TBC',
    address: node.venue ? node.venue.address : '',
    city: node.venue ? node.venue.city : 'Leeds',
    url: node.eventUrl,
    going: node.going,
    maxTickets: node.maxTickets || null,
    upcoming: isUpcoming,
  };
}
