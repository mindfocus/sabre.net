using Pchp.Core;
using Pchp.Library;
using Sabre.CalDAV.Backend;
using Sabre.DAV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sabre.net.tests.sabre.CalDAV.Backend
{
    class Mock : AbstractBackend
    {
        private PhpArray calendars ;
        private PhpArray calendarData ;
        private Context context;
        public Mock(PhpArray calendars , PhpArray calendarData, Context context ) : base(context)
        {
            foreach(var calendar in calendars)
            {
                //if(calendar["id"] == null)
                //{
                //    calendar["id"] = UUIDUtil.getUUID(context);
                //}
            }
            this.calendars = calendars;
            this.calendarData = calendarData;
            this.context = context;
        }
            /**
     * Returns a list of calendars for a principal.
     *
     * Every project is an array with the following keys:
     *  * id, a unique id that will be used by other functions to modify the
     *    calendar. This can be the same as the uri or a database key.
     *  * uri, which the basename of the uri with which the calendar is
     *    accessed.
     *  * principalUri. The owner of the calendar. Almost always the same as
     *    principalUri passed to this method.
     *
     * Furthermore it can contain webdav properties in clark notation. A very
     * common one is '{DAV:}displayname'.
     *
     * @param string $principalUri
     *
     * @return array
     */
    public override PhpValue getCalendarsForUser(PhpValue principalUri)
    {
        var r = new PhpArray();
        foreach (var row in calendars) {
            //if (row["principaluri"] == principalUri) {
                r.Add(row);
            //}
        }

        return r;
    }
         /**
     * Creates a new calendar for a principal.
     *
     * If the creation was a success, an id must be returned that can be used to reference
     * this calendar in other methods, such as updateCalendar.
     *
     * This function must return a server-wide unique id that can be used
     * later to reference the calendar.
     *
     * @param string $principalUri
     * @param string $calendarUri
     *
     * @return string|int
     */
    public override PhpValue createCalendar(PhpValue principalUri, PhpValue calendarUri, PhpArray properties)
    {
        var id = UUIDUtil.getUUID(context);
            var tempArray = new PhpArray();
            tempArray.Add("id", id);
            tempArray.Add("principaluri", principalUri);
            tempArray.Add("uri", calendarUri);
            var keyv2 = new PhpArray();
            keyv2.Add("VEVENT");
            keyv2.Add("VTODO");
            tempArray.Add("{" + Sabre.CalDAV.Plugin.NS_CALDAV + "}supported-calendar-component-set" , new Sabre.CalDAV.Xml.Property.SupportedCalendarComponentSet(keyv2));
            calendars = Arrays.array_merge(tempArray, properties);
        return id;
    }
        /**
     * Updates properties for a calendar.
     *
     * The list of mutations is stored in a Sabre\DAV\PropPatch object.
     * To do the actual updates, you must tell this object which properties
     * you're going to process with the handle() method.
     *
     * Calling the handle method is like telling the PropPatch object "I
     * promise I can handle updating this property".
     *
     * Read the PropPatch documentation for more info and examples.
     *
     * @param mixed $calendarId
     */
    public override PhpValue updateCalendar(PhpValue calendarId, Sabre.DAV.PropPatch propPatch)
    {
            return true;
        //$propPatch->handleRemaining(function ($props) use ($calendarId) {
        //    foreach ($this->calendars as $k => $calendar) {
        //        if ($calendar['id'] === $calendarId) {
        //            foreach ($props as $propName => $propValue) {
        //                if (is_null($propValue)) {
        //                    unset($this->calendars[$k][$propName]);
        //                } else {
        //                    $this->calendars[$k][$propName] = $propValue;
        //                }
        //            }

        //            return true;
        //        }
        //    }
        //});
    }
          /**
     * Delete a calendar and all it's objects.
     *
     * @param string $calendarId
     */
    public override PhpValue deleteCalendar(PhpValue calendarId)
    {
            foreach(var calendar in this.calendars)
            {
                if(calendar.Key.String == "id" && calendar.Key.String == calendarId)
                {
                    this.calendars.Remove(calendar);
                }
            }
            return PhpValue.Null;
        //foreach ($this->calendars as $k => $calendar) {
        //    if ($calendar['id'] === $calendarId) {
        //        unset($this->calendars[$k]);
        //    }
        //}
    }
            /**
     * Returns all calendar objects within a calendar object.
     *
     * Every item contains an array with the following keys:
     *   * id - unique identifier which will be used for subsequent updates
     *   * calendardata - The iCalendar-compatible calendar data
     *   * uri - a unique key which will be used to construct the uri. This can be any arbitrary string.
     *   * lastmodified - a timestamp of the last modification time
     *   * etag - An arbitrary string, surrounded by double-quotes. (e.g.:
     *   '  "abcdef"')
     *   * calendarid - The calendarid as it was passed to this function.
     *
     * Note that the etag is optional, but it's highly encouraged to return for
     * speed reasons.
     *
     * The calendardata is also optional. If it's not returned
     * 'getCalendarObject' will be called later, which *is* expected to return
     * calendardata.
     *
     * @param string $calendarId
     *
     * @return array
     */
    public override PhpValue getCalendarObjects(PhpValue calendarId)
    {
            if(!this.calendarData.ContainsKey(calendarId))
            {
                return PhpArray.Empty;
            }
            
            var objects = this.calendarData.GetItemValue(calendarId);
            foreach(var obj in objects)
            {
                
            }
            return objects.AsArray();
        //foreach ($objects as $uri => &$object) {
        //    $object['calendarid'] = $calendarId;
        //    $object['uri'] = $uri;
        //    $object['lastmodified'] = null;
        //}

        //return $objects;
    }
            /**
     * Returns information from a single calendar object, based on it's object
     * uri.
     *
     * The object uri is only the basename, or filename and not a full path.
     *
     * The returned array must have the same keys as getCalendarObjects. The
     * 'calendardata' object is required here though, while it's not required
     * for getCalendarObjects.
     *
     * This method must return null if the object did not exist.
     *
     * @param mixed  $calendarId
     * @param string $objectUri
     *
     * @return array|null
     */
    public override PhpValue getCalendarObject(PhpValue calendarId, PhpValue objectUri)
    {
            if(!this.calendarData.Contains(calendarId))
            {
                return PhpValue.Null;
            }
            var obj = this.calendarData.GetItemValue(calendarId).AsArray().GetItemValue(objectUri).AsArray();
            obj.Add("calendarid", calendarId);
            obj.Add("uri", objectUri);
            obj.Add("lastmodified", PhpValue.Null);
            return obj;
        //if (!isset($this->calendarData[$calendarId][$objectUri])) {
        //    return null;
        //}
        //$object = $this->calendarData[$calendarId][$objectUri];
        //$object['calendarid'] = $calendarId;
        //$object['uri'] = $objectUri;
        //$object['lastmodified'] = null;

        //return $object;
    }
         /**
     * Creates a new calendar object.
     *
     * @param string $calendarId
     * @param string $objectUri
     * @param string $calendarData
     */
    public override PhpValue createCalendarObject(PhpValue calendarId, PhpValue objectUri, PhpValue calendarData)
    {
        //$this->calendarData[$calendarId][$objectUri] = [
        //    'calendardata' => $calendarData,
        //    'calendarid' => $calendarId,
        //    'uri' => $objectUri,
        //];

        //return '"'.md5($calendarData).'"';
        return PhpValue.Null;
    }
         /**
     * Updates an existing calendarobject, based on it's uri.
     *
     * @param string $calendarId
     * @param string $objectUri
     * @param string $calendarData
     */
    public override PhpValue updateCalendarObject(PhpValue calendarId, PhpValue objectUri, PhpValue calendarData)
    {
        //$this->calendarData[$calendarId][$objectUri] = [
        //    'calendardata' => $calendarData,
        //    'calendarid' => $calendarId,
        //    'uri' => $objectUri,
        //];

        //return '"'.md5($calendarData).'"';
        return PhpValue.Null;
    }
         /**
     * Deletes an existing calendar object.
     *
     * @param string $calendarId
     * @param string $objectUri
     */
    public override PhpValue deleteCalendarObject(PhpValue calendarId, PhpValue objectUri)
    {
        //unset($this->calendarData[$calendarId][$objectUri]);
        return PhpValue.Null;
    }
    }
}
